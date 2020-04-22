using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerService.Services.Interfaces;
using FlowerService.ViewModels;
using FlowerServiceLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlowerService.Controllers {


    public class PlantationsController : Controller {
        private IFlowerServiceRepository _flowerServiceRepository;

        public PlantationsController(IFlowerServiceRepository flowerServiceRepository) {
            _flowerServiceRepository = flowerServiceRepository;
        }
        public IActionResult Index() {
            ViewBag.Plantations = _flowerServiceRepository.PlantationRepository.All();
            return View();
        }


        public IActionResult Details(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Plantation plantation = _flowerServiceRepository.PlantationRepository.Get(id.Value);

            if (plantation == null)
            {
                //TODO Redirect to 404
                RedirectToAction("Index");
            }

            return View(plantation);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Plantation plantation) {
            if (!ModelState.IsValid)
            {
                return View(plantation);
            }

            _flowerServiceRepository.PlantationRepository.Create(plantation);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id) {
            if (id == null)
                return RedirectToAction("Index");

            Plantation plantationToEdit = _flowerServiceRepository.PlantationRepository.Get(id.Value);

            if (plantationToEdit == null)
            {
                return RedirectToAction("Index");
            }

            return View(plantationToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Plantation plantation) {
            if (!ModelState.IsValid)
            {
                return View(plantation);
            }

            _flowerServiceRepository.PlantationRepository.Update(plantation);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Plantation plantationToDelete = _flowerServiceRepository.PlantationRepository.Get(id.Value);

            if (plantationToDelete == null)
            {
                return RedirectToAction("Index");
            }

            _flowerServiceRepository.PlantationRepository.Delete(plantationToDelete);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult FlowerCreate(int? id) {
            if (id == null || _flowerServiceRepository.PlantationRepository.Get(id.Value) == null)
                return RedirectToAction("Index");

            ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
            PlantationFlower plantationFlower = new PlantationFlower { PlaceId = id.Value };
            return View(plantationFlower);
        }

        [HttpPost]
        public IActionResult FlowerCreate(PlantationFlower plantationFlower) {
            if (!ModelState.IsValid)
            {
                return View(plantationFlower);
            }

            Plantation plantation = _flowerServiceRepository.PlantationRepository.Get(plantationFlower.PlaceId);
            if (plantation.PlantationFlowers.FirstOrDefault(flowers => flowers.PlaceId == plantationFlower.PlaceId && flowers.FlowerId == plantationFlower.FlowerId) != null)
            {
                ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
                ModelState["FlowerId"].Errors.Add("Такой цветок уже есть на плантации");
                return View(plantationFlower);
            }

            _flowerServiceRepository.PlantationRepository.CreatePlantationFlower(plantationFlower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = plantationFlower.PlaceId });
        }

        public IActionResult FlowerDetails(int? placeId,int? flowerId) {
            if (placeId == null || flowerId==null || _flowerServiceRepository.PlantationRepository.Get(placeId.Value) == null)
                return RedirectToAction("Index");

            PlantationFlower plantationFlower = _flowerServiceRepository.PlantationRepository.GetPlantationFlowers(placeId.Value).SingleOrDefault(pf => pf.PlaceId == placeId && pf.FlowerId == flowerId.Value);

            if (plantationFlower == null)
                return RedirectToAction("Index");

            return View(plantationFlower);
        }

        public IActionResult FlowerEdit(int? placeId,int? flowerId) {
            if (placeId == null || flowerId == null || _flowerServiceRepository.PlantationRepository.Get(placeId.Value) == null)
                return RedirectToAction("Index");
            
            ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");

            PlantationFlower plantationFlower = _flowerServiceRepository.PlantationRepository.GetPlantationFlowers(placeId.Value).SingleOrDefault(pf => pf.PlaceId == placeId && pf.FlowerId == flowerId.Value);

            if (plantationFlower == null)
                return RedirectToAction("Index");

            return View(plantationFlower);
        }

        [HttpPost]
        public IActionResult FlowerEdit(PlantationFlower plantationFlower) {
            if (!ModelState.IsValid)
            {
                ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
                return View(plantationFlower);
            }

            _flowerServiceRepository.PlantationRepository.UpdatePlantationFlower(plantationFlower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = plantationFlower.PlaceId });
        }

        public IActionResult FlowerDelete(int? placeId, int? flowerId) {
            if (placeId != null || flowerId != null || _flowerServiceRepository.PlantationRepository.Get(placeId.Value) != null)
            {
                var plantation = _flowerServiceRepository.PlantationRepository.Get(placeId.Value);
                var plantationFlower = plantation.PlantationFlowers.FirstOrDefault(item => item.PlaceId == placeId.Value && item.FlowerId == flowerId.Value);
                if (plantationFlower != null)
                {
                    _flowerServiceRepository.PlantationRepository.DeletePlantationFlower(plantationFlower);
                    _flowerServiceRepository.SaveChanges();
                    return RedirectToAction("Edit",new { id = placeId });
                }

            }
            return RedirectToAction("Index");

        }
    }
}
