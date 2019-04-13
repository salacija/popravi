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
using Popravi.Mvc.Areas.Admin.Models;

namespace Popravi.Mvc.Areas.Admin.Controllers
{
    public class LocationController : Controller
    {
        private readonly ILocationService _service;
        private readonly ICityService _cityService;

        public LocationController(ILocationService locationService, ICityService cityService)
        {
            _service = locationService;
            _cityService = cityService;
        }

        // GET: Location
        public IActionResult Index(int perPage = 5, int pageNumber = 1)
        {
            return View(_service.GetAll(pageNumber, perPage));
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            ViewBag.Cities = _cityService.GetAll();
            return View();
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLocationDto dto)
        {
            ViewBag.Cities = _cityService.GetAll();

            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                _service.Add(dto);
                TempData["success"] = "Lokacija uspesno dodata.";
                return RedirectToAction("index");
            }
            catch (EntityAlreadyExistsException e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("create");
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction("index");
            }
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            var vm = new EditLocationViewModel();
            vm.Cities = _cityService.GetAll();
            vm.Location = _service.Find(id);
            return View(vm);
        }

        // POST: Location/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CreateLocationDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                _service.Update(id, dto);
                TempData["success"] = "Uspesna izmena lokacije.";
                return RedirectToAction("index");
            }
            catch
            {
                TempData["error"] = "Doslo je do greske na serveru, lokacija nije izmenjena.";
                return View();
            }
        }

        // GET: Location/Delete/5
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                TempData["success"] = "Uspesno obrisana lokacija.";
            }
            catch
            {
                TempData["error"] = "Doslo je do greske pri brisanju.";
            }
            return RedirectToAction("index");
        }
    }
}