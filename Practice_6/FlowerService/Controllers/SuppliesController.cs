using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlowerService.Services.Interfaces;
using FlowerServiceLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FlowerService.Controllers
{
    public class SuppliesController : Controller
    {
        private IFlowerServiceRepository _flowerServiceRepository;
        private readonly List<SelectListItem> SupplyStatuses= new List<SelectListItem> { new SelectListItem("Scheduled", "Scheduled"), new SelectListItem("InProgress", "InProgress"), new SelectListItem("Closed", "Closed"), new SelectListItem("Canceled", "Canceled") };


    public SuppliesController(IFlowerServiceRepository flowerServiceRepository) {
            _flowerServiceRepository = flowerServiceRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Supplies = _flowerServiceRepository.SupplyRepository.All();
            return View();
        }

        public IActionResult Create() {
            ViewBag.Plantations = new SelectList(_flowerServiceRepository.PlantationRepository.All(),"Id","Name");
            ViewBag.Warehouses = new SelectList(_flowerServiceRepository.WarehouseRepository.All(), "Id", "Name");
            ViewBag.Statuses = SupplyStatuses;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Supply supply) {
            if (!ModelState.IsValid)
            {
                ViewBag.Plantations = new SelectList(_flowerServiceRepository.PlantationRepository.All(), "Id", "Name");
                ViewBag.Warehouses = new SelectList(_flowerServiceRepository.WarehouseRepository.All(), "Id", "Name");
                ViewBag.Statuses = SupplyStatuses;

                return View(supply);
            }

            _flowerServiceRepository.SupplyRepository.Create(supply);
            _flowerServiceRepository.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Supply supply = _flowerServiceRepository.SupplyRepository.Get(id.Value);

            if (supply == null)
            {
                //TODO Redirect to 404
                RedirectToAction("Index");
            }

            return View(supply);
        }

        public IActionResult Edit(int? id) {
            if (id == null)
                return RedirectToAction("Index");

            Supply supplyToEdit = _flowerServiceRepository.SupplyRepository.Get(id.Value);

            if (supplyToEdit == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Plantations = new SelectList(_flowerServiceRepository.PlantationRepository.All(), "Id", "Name");
            ViewBag.Warehouses = new SelectList(_flowerServiceRepository.WarehouseRepository.All(), "Id", "Name");
            ViewBag.Statuses = SupplyStatuses;
            return View(supplyToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Supply supply) {
            if (!ModelState.IsValid)
            {
                supply.SupplyFlowers = _flowerServiceRepository.SupplyRepository.Get(supply.Id).SupplyFlowers;

                ViewBag.Plantations = new SelectList(_flowerServiceRepository.PlantationRepository.All(), "Id", "Name");
                ViewBag.Warehouses = new SelectList(_flowerServiceRepository.WarehouseRepository.All(), "Id", "Name");
                ViewBag.Statuses = SupplyStatuses;
                return View(supply);
            }

            _flowerServiceRepository.SupplyRepository.Update(supply);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Supply supplyToDelete = _flowerServiceRepository.SupplyRepository.Get(id.Value);

            if (supplyToDelete == null)
            {
                return RedirectToAction("Index");
            }

            _flowerServiceRepository.SupplyRepository.Delete(supplyToDelete);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult FlowerCreate(int? id) {
            if (id == null || _flowerServiceRepository.SupplyRepository.Get(id.Value) == null)
                return RedirectToAction("Index");

            ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
            SupplyFlower supplyFlower = new SupplyFlower { SupplyId = id.Value };
            return View(supplyFlower);
        }

        [HttpPost]
        public IActionResult FlowerCreate(SupplyFlower supplyFlower) {
            if (!ModelState.IsValid)
            {
                return View(supplyFlower);
            }

            Supply supply = _flowerServiceRepository.SupplyRepository.Get(supplyFlower.SupplyId);
            if (supply.SupplyFlowers.FirstOrDefault(flowers => flowers.SupplyId == supplyFlower.SupplyId && flowers.FlowerId == supplyFlower.FlowerId) != null)
            {
                ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
                ModelState["FlowerId"].Errors.Add("Такой цветок уже есть в поставке");
                return View(supplyFlower);
            }

            _flowerServiceRepository.SupplyRepository.CreateSupplyFlower(supplyFlower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = supplyFlower.SupplyId });
        }

        public IActionResult FlowerDetails(int? supplyId, int? flowerId) {
            if (supplyId == null || flowerId == null || _flowerServiceRepository.SupplyRepository.Get(supplyId.Value) == null)
                return RedirectToAction("Index");

            SupplyFlower supplyFlower = _flowerServiceRepository.SupplyRepository.GetSupplyFlowers(supplyId.Value).SingleOrDefault(item => item.SupplyId == supplyId && item.FlowerId == flowerId.Value);

            if (supplyFlower == null)
                return RedirectToAction("Index");

            return View(supplyFlower);
        }

        public IActionResult FlowerEdit(int? supplyId, int? flowerId) {
            if (supplyId == null || flowerId == null || _flowerServiceRepository.SupplyRepository.Get(supplyId.Value) == null)
                return RedirectToAction("Index");

            ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");

            SupplyFlower supplyFlower = _flowerServiceRepository.SupplyRepository.GetSupplyFlowers(supplyId.Value).SingleOrDefault(item => item.SupplyId == supplyId && item.FlowerId == flowerId.Value);

            if (supplyFlower == null)
                return RedirectToAction("Index");

            return View(supplyFlower);
        }

        [HttpPost]
        public IActionResult FlowerEdit(SupplyFlower supplyFlower) {
            if (!ModelState.IsValid)
            {
                ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
                return View(supplyFlower);
            }

            _flowerServiceRepository.SupplyRepository.UpdateSupplyFlower(supplyFlower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = supplyFlower.SupplyId });
        }

        public IActionResult FlowerDelete(int? supplyId, int? flowerId) {
            if (supplyId != null || flowerId != null || _flowerServiceRepository.SupplyRepository.Get(supplyId.Value) != null)
            {
                Supply supply = _flowerServiceRepository.SupplyRepository.Get(supplyId.Value);
                SupplyFlower supplyFlower = supply.SupplyFlowers.FirstOrDefault(item => item.SupplyId == supplyId.Value && item.FlowerId == flowerId.Value);
                if (supplyFlower != null)
                {
                    _flowerServiceRepository.SupplyRepository.DeleteSupplyFlower(supplyFlower);
                    _flowerServiceRepository.SaveChanges();
                    return RedirectToAction("Edit", new { id = supplyId });
                }

            }
            return RedirectToAction("Index");

        }
    }
}