using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Popravi.Business.DataTransfer;
using Popravi.Business.DataTransfer.User;
using Popravi.Business.Exceptions;
using Popravi.Business.Services.EfServices;
using Popravi.Business.Services.Interfaces;
using Popravi.DataAccess;
using Popravi.Mvc.Helpers;
using Popravi.Mvc.Models;

namespace Popravi.Mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index(int pageNumber = 1)
        {
            var usersDto = _service.GetAll(pageNumber, 2);
            var vm = new UsersViewModel();
            vm.Users = usersDto;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserDto user)
        {
            try
            {
                var uuid = Guid.NewGuid();
                user.Uuid = uuid.ToString();

                var password = PasswordGenerator.Make(user.Password);
                user.Password = password;

                _service.Add(user);

                using (var message = new MailMessage())
                {
                    message.To.Add(new MailAddress(user.Email, user.FirstName + user.LastName));
                    message.From = new MailAddress("milica.cica7@gmail.com", "Popravi.com Tim");
                    message.Subject = "Uspešna registracija!";
                    message.Body = $"Uspešno ste se registrovali! Kliknite <a href='https://localhost:44323/user/activate?code={user.Uuid}'>ovde</a> da biste aktivirali svoj nalog.";
                    message.IsBodyHtml = true;

                    using (var client = new SmtpClient("smtp.gmail.com"))
                    {
                        client.Port = 587;
                        client.Credentials = new NetworkCredential("milica.cica7@gmail.com", "teamlukic");
                        client.EnableSsl = true;
                        client.Send(message);
                    }
                }

                TempData["success"] = $"Uspesna registracija. Aktivacioni link je poslat na {user.Email}";
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Activate(ActivateCodeDto dto)
        {
            
            try
            {
                _service.ActivateUser(dto.Code);
                ViewBag.Message = "Uspesna aktivacija profila.";
            }
            catch(UserAlreadyActiveException)
            {
                ViewBag.Message = "Ovaj nalog je vec aktiviran.";
            }
            
            catch(EntityNotFoundException)
            {
                return NotFound();
            }

            return View();
        }

        //Pristup profilu ima iskljucivo ulogovan korisnik
        //Ukoliko u sesiji nema korisnika, trenutnog korisnika koji pokusava da pristupi
        //Prebacujemo na index stranu
        public IActionResult Profile()
        {
            if (HttpContext.Session.Keys.Contains("User"))
            {
                var user = HttpContext.Session.Get<LoggedUserDto>("User");
                var result = _service.Find(user.Id);
                return View(result);
            }
            return RedirectToAction("index"); 
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var user = HttpContext.Session.Get<LoggedUserDto>("User");
            if(user != null)
            {
                var result = _service.Find(user.Id);
                return View(result);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult Edit(UserDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var user = HttpContext.Session.Get<LoggedUserDto>("User");
                _service.Update(user.Id, dto);
                return RedirectToAction("profile");
            }
            catch
            {
                TempData["error"] = "Doslo je do greske prilikom menjanja. Podaci nisu izmenjeni.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditPassword()
        {
            var user = HttpContext.Session.Get<LoggedUserDto>("User");
            if (user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        [HttpPost]
        public IActionResult EditPassword(ChangePasswordViewModel vm)
        {
            var user = HttpContext.Session.Get<LoggedUserDto>("User");

            var sifra = PasswordGenerator.Make(vm.OldPassword);

            var result = _service.IsOldPasswordCorrect(sifra, user.Id);

            if (!result)
            {
                TempData["error"] = "Stara loznika nije ispravna.";
                return View();
            }

            if(vm.NewPassword != vm.NewPasswordConfirm)
            {
                TempData["error"] = "Lozinke se ne poklapaju.";
                return View();
            }

            try
            {
                var password = PasswordGenerator.Make(vm.NewPassword);

                _service.UpdateUserPassword(password, user.Id);
                TempData["success"] = "Uspesno izmenjena loznika.";
                return RedirectToAction("profile");
            }
            catch
            {
                TempData["error"] = "Doslo je do greske pri izmeni.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto user)
        {
            var password = PasswordGenerator.Make(user.Password);

            var result = _service.FindUser(user.UserName, password);
            //Da bi koristili sesiju, u Startup.cs smo dodali services.AddSession() i app.UseSession()
            //Pored toga dodali smo klasu SessionExtensions.cs u Popravi.Mvc osnovnom (root - ne wwwroot) folderu
            if(result != null)
            {
                HttpContext.Session.Set("User", result);
                return RedirectToAction("profile");
            }

            TempData["error"] = "Neispravno korisnicko ime ili lozinka ili nalog nije aktivan.";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("login");
        }


    }
}