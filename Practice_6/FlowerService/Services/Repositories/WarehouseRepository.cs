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

        public Warehouse Get(int id) {
            return Context.Warehouses.SingleOrDefault(warehouse => warehouse.Id == id);
        }
    }
}
