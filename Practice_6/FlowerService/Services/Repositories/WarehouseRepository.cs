using FlowerService.Services.Interfaces;
using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Repositories {
    public class WarehouseRepository : RepositoryBase<Warehouse>, IWarehouseRepository {
        public WarehouseRepository(FlowerServiceContext context) : base(context) {
        }

        public void CreateWarehouseFlower(WarehouseFlower warehouseFlower) {
            Context.Warehouses.SingleOrDefault(warehouse => warehouse.Id == warehouseFlower.PlaceId).WarehouseFlowers.Add(warehouseFlower); 
        }

        public void DeleteWarehouseFlower(WarehouseFlower warehouseFlower) {
            Context.Warehouses.SingleOrDefault(warehouse => warehouse.Id == warehouseFlower.PlaceId).WarehouseFlowers.Remove(warehouseFlower);
        }

        public Warehouse Get(int id) {
            return Context.Warehouses.SingleOrDefault(warehouse => warehouse.Id == id);
        }

        public IEnumerable<WarehouseFlower> GetWarehouseFlowers(int id) {
            return Context.Warehouses.SingleOrDefault(warehouse => warehouse.Id == id).WarehouseFlowers;
        }

        public void UpdateWarehouseFlower(WarehouseFlower warehouseFlower) {
            Context.WarehouseFlowers.Update(warehouseFlower);
        }
    }
}
