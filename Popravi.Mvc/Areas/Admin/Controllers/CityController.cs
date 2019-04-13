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
    public class CityController : Controller
    {
        private readonly ICityService _service;

        public CityController(ICityService service)
        {
            _service = service;
        }

        // GET: City
        public IActionResult Index(int pageNumber = 1)
        {
            return View(_service.GetAll(pageNumber, 5));
        }

        // GET: Cities/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CityDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {

                _service.Add(dto);
                TempData["success"] = "Grad je uspesno dodat.";
                return RedirectToAction(nameof(Index));
            }
            catch(EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("create");
            }
            catch(Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("index");
            }
        }

        // GET: Cities/Edit/5
        public ActionResult Edit(int id)
        {
            var city = _service.Find(id);
            return View(city);
        }

        // POST: Cities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CityDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                _service.Update(id,dto);
                TempData["success"] = "Uspesna izmena grada.";
                return RedirectToAction("index");
            }
            catch(EntityNotFoundException e)
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

        // GET: Cities/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                TempData["success"] = "Uspesno obrisan grad.";
            }
            catch
            {
                TempData["error"] = "Doslo je do greske pri brisanju.";
            }
            return RedirectToAction("index");
        }
    }
}