using FlowerService.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Repositories {
    public class FlowerServiceRepository : IFlowerServiceRepository {

        private FlowerServiceContext _context;
        private IFlowerRepository _flowerRepository;
        private IPlantationRepository _plantationRepository;
        private IWarehouseRepository _warehouseRepository;
        public IFlowerRepository FlowerRepository {
            get {
                if (_flowerRepository == null)
                    _flowerRepository = new FlowerRepository(_context);
                return _flowerRepository;
            }
        }

        public IPlantationRepository PlantationRepository {
            get {
                if (_plantationRepository == null)
                    _plantationRepository = new PlantationRepository(_context);
                return _plantationRepository;
            }
        }

        public IWarehouseRepository WarehouseRepository {
            get {
                if (_warehouseRepository == null)
                    _warehouseRepository = new WarehouseRepository(_context);
                return _warehouseRepository;
            }
        }

        public FlowerServiceRepository(FlowerServiceContext context) {
            _context = context;
        }
        public void SaveChanges() {
            _context.SaveChanges();
        }
    }
}
