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
        private ISupplyRepository _supplyRepository;
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
        public ISupplyRepository SupplyRepository {
            get {
                if (_supplyRepository == null)
                    _supplyRepository = new SupplyRepository(_context);
                return _supplyRepository;
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
