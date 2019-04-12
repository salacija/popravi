using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Popravi.Business.DataTransfer;
using Popravi.Business.Exceptions;
using Popravi.Business.Services.EfServices;
using Popravi.Business.Services.Interfaces;
using Popravi.DataAccess;

namespace Popravi.Mvc.Areas.Admin.Controllers
{
    public class MalfunctionController : Controller
    {
        private readonly IMalfunctionService _service;

        public MalfunctionController()
        {
            var context = new PopraviDbContext();
            _service = new EfMalfunctionService(context);
        }

        // GET: Malfunction
        public ActionResult Index(int pageNumber = 1)
        {
            return View(_service.GetAllMalfunctions(pageNumber, 5));
        }

        // GET: Malfunction/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Malfunction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Malfunction/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MalfunctionDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                _service.AddMalfunction(dto);
                TempData["success"] = "Kvar je uspesno dodat.";
                return RedirectToAction("index");
             }
            catch(EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return View();
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("index");
            }
        }

        // GET: Malfunction/Edit/5
        public ActionResult Edit(int id)
        {
            var malfunction = _service.FindMalfunction(id);
            return View(malfunction);
        }

        // POST: Malfunction/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MalfunctionDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                _service.UpdateMalfunction(id, dto);
                TempData["success"] = "Uspesna izmena kvara.";
                return RedirectToAction(nameof(Index));
            }
            catch (EntityNotFoundException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("index");
            }
            catch(Exception e)
            {
                TempData["error"] = "Doslo je do greske na serveru, izmena nije uspela.";
                return View();
            }
        }

        // GET: Malfunction/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                _service.DeleteMalfunction(id);
                TempData["success"] = "Uspesno obrisan kvar.";
            }
            catch
            {
                TempData["error"] = "DOslo je do greske pri brisanju.";
            }
            return RedirectToAction("index");
        }
    }
}