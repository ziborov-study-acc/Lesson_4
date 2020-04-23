using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Interfaces {
    public interface ISupplyRepository : IRepositoryBase<Supply> {
        Supply Get(int id);

        void CreateSupplyFlower(SupplyFlower supplyFlower);
        void UpdateSupplyFlower(SupplyFlower supplyFlower);
        void DeleteSupplyFlower(SupplyFlower supplyFlower);
        IEnumerable<SupplyFlower> GetSupplyFlowers(int id);
    }
}
