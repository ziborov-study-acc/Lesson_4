using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerService.Services.Interfaces;
using FlowerServiceLibrary;
using Microsoft.AspNetCore.Mvc;

namespace FlowerService.Controllers
{
    public class FlowersController : Controller
    {
        private IFlowerServiceRepository _flowerServiceRepository;

        public FlowersController(IFlowerServiceRepository flowerServiceRepository) {
            _flowerServiceRepository = flowerServiceRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Flowers = _flowerServiceRepository.FlowerRepository.All();
            return View();
        }


        public IActionResult Details(int? id) {

            if (id == null)
                return RedirectToAction("Index");
            
            Flower flower = _flowerServiceRepository.FlowerRepository.Get(id.Value);

            if (flower == null)
            {
                //TODO Redirect to 404
                RedirectToAction("Index");
            }

            return View(flower);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Flower flower) {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _flowerServiceRepository.FlowerRepository.Create(flower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id) {
            if (id == null)
                return RedirectToAction("Index");

            Flower flowerToEdit = _flowerServiceRepository.FlowerRepository.Get(id.Value);

            if (flowerToEdit == null)
            {
                return RedirectToAction("Index");
            }

            return View(flowerToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Flower flower) {
            if (!ModelState.IsValid)
            {
                return View(flower);
            }

            _flowerServiceRepository.FlowerRepository.Update(flower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Flower flowerToDelete = _flowerServiceRepository.FlowerRepository.Get(id.Value);

            if (flowerToDelete == null)
            {
                return RedirectToAction("Index");
            }

            _flowerServiceRepository.FlowerRepository.Delete(flowerToDelete);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}