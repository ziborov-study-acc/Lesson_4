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
    public class WarehousesController : Controller
    {
        private IFlowerServiceRepository _flowerServiceRepository;

        public WarehousesController(IFlowerServiceRepository flowerServiceRepository) {
            _flowerServiceRepository = flowerServiceRepository;
        }
        public IActionResult Index()
        {
            ViewBag.Warehouses = _flowerServiceRepository.WarehouseRepository.All();
            return View();
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Warehouse warehouse) {
            if (!ModelState.IsValid)
            {
                return View(warehouse);
            }

            _flowerServiceRepository.WarehouseRepository.Create(warehouse);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Details(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Warehouse warehouse = _flowerServiceRepository.WarehouseRepository.Get(id.Value);

            if (warehouse == null)
            {
                //TODO Redirect to 404
                RedirectToAction("Index");
            }

            return View(warehouse);
        }

        public IActionResult Edit(int? id) {
            if (id == null)
                return RedirectToAction("Index");

            Warehouse warehouseToEdit = _flowerServiceRepository.WarehouseRepository.Get(id.Value);

            if (warehouseToEdit == null)
            {
                return RedirectToAction("Index");
            }

            return View(warehouseToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Warehouse warehouse) {
            if (!ModelState.IsValid)
            {
                return View(warehouse);
            }

            _flowerServiceRepository.WarehouseRepository.Update(warehouse);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id) {

            if (id == null)
                return RedirectToAction("Index");

            Warehouse warehouseToDelete = _flowerServiceRepository.WarehouseRepository.Get(id.Value);

            if (warehouseToDelete == null)
            {
                return RedirectToAction("Index");
            }

            _flowerServiceRepository.WarehouseRepository.Delete(warehouseToDelete);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult FlowerCreate(int? id) {
            if (id == null || _flowerServiceRepository.WarehouseRepository.Get(id.Value) == null)
                return RedirectToAction("Index");

            ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
            WarehouseFlower warehouseFlower = new WarehouseFlower { PlaceId = id.Value };
            return View(warehouseFlower);
        }

        [HttpPost]
        public IActionResult FlowerCreate(WarehouseFlower warehouseFlower) {
            if (!ModelState.IsValid)
            {
                return View(warehouseFlower);
            }

            Warehouse warehouse = _flowerServiceRepository.WarehouseRepository.Get(warehouseFlower.PlaceId);
            if (warehouse.WarehouseFlowers.FirstOrDefault(flowers => flowers.PlaceId == warehouseFlower.PlaceId && flowers.FlowerId == warehouseFlower.FlowerId) != null)
            {
                ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
                ModelState["FlowerId"].Errors.Add("Такой цветок уже есть на плантации");
                return View(warehouseFlower);
            }

            _flowerServiceRepository.WarehouseRepository.CreateWarehouseFlower(warehouseFlower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = warehouseFlower.PlaceId });
        }

        public IActionResult FlowerDetails(int? placeId, int? flowerId) {
            if (placeId == null || flowerId == null || _flowerServiceRepository.WarehouseRepository.Get(placeId.Value) == null)
                return RedirectToAction("Index");

            WarehouseFlower warehouseFlower = _flowerServiceRepository.WarehouseRepository.GetWarehouseFlowers(placeId.Value).SingleOrDefault(pf => pf.PlaceId == placeId && pf.FlowerId == flowerId.Value);

            if (warehouseFlower == null)
                return RedirectToAction("Index");

            return View(warehouseFlower);
        }

        public IActionResult FlowerEdit(int? placeId, int? flowerId) {
            if (placeId == null || flowerId == null || _flowerServiceRepository.WarehouseRepository.Get(placeId.Value) == null)
                return RedirectToAction("Index");

            ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");

            WarehouseFlower warehouseFlower = _flowerServiceRepository.WarehouseRepository.GetWarehouseFlowers(placeId.Value).SingleOrDefault(pf => pf.PlaceId == placeId && pf.FlowerId == flowerId.Value);

            if (warehouseFlower == null)
                return RedirectToAction("Index");

            return View(warehouseFlower);
        }

        [HttpPost]
        public IActionResult FlowerEdit(WarehouseFlower warehouseFlower) {
            if (!ModelState.IsValid)
            {
                ViewBag.Flowers = new SelectList(_flowerServiceRepository.FlowerRepository.All(), "Id", "Name");
                return View(warehouseFlower);
            }

            _flowerServiceRepository.WarehouseRepository.UpdateWarehouseFlower(warehouseFlower);
            _flowerServiceRepository.SaveChanges();

            return RedirectToAction("Edit", new { id = warehouseFlower.PlaceId });
        }

        public IActionResult FlowerDelete(int? placeId, int? flowerId) {
            if (placeId != null || flowerId != null || _flowerServiceRepository.WarehouseRepository.Get(placeId.Value) != null)
            {
                Warehouse warehouse = _flowerServiceRepository.WarehouseRepository.Get(placeId.Value);
                WarehouseFlower warehouseFlower = warehouse.WarehouseFlowers.FirstOrDefault(item => item.PlaceId == placeId.Value && item.FlowerId == flowerId.Value);
                if (warehouseFlower != null)
                {
                    _flowerServiceRepository.WarehouseRepository.DeleteWarehouseFlower(warehouseFlower);
                    _flowerServiceRepository.SaveChanges();
                    return RedirectToAction("Edit", new { id = placeId });
                }

            }
            return RedirectToAction("Index");

        }
    }


}