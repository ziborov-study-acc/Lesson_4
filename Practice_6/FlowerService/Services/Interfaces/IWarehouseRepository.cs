﻿using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Interfaces {
    public interface IWarehouseRepository : IRepositoryBase<Warehouse> {
        Warehouse Get(int id);

        void CreateWarehouseFlower(WarehouseFlower warehouseFlower);
        void UpdateWarehouseFlower(WarehouseFlower warehouseFlower);
        void DeleteWarehouseFlower(WarehouseFlower warehouseFlower);

        IEnumerable<WarehouseFlower> GetWarehouseFlowers(int id);
    }
}
