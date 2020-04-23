using FlowerService.Services.Interfaces;
using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Repositories {
    public class SupplyRepository : RepositoryBase<Supply>, ISupplyRepository {

        public SupplyRepository(FlowerServiceContext context):base(context) {
        }

        public void CreateSupplyFlower(SupplyFlower supplyFlower) {
            Context.Supply.SingleOrDefault(supply => supply.Id == supplyFlower.SupplyId).SupplyFlowers.Add(supplyFlower);
        }

        public void DeleteSupplyFlower(SupplyFlower supplyFlower) {
            Context.Supply.SingleOrDefault(supply => supply.Id == supplyFlower.SupplyId).SupplyFlowers.Remove(supplyFlower);
        }

        public Supply Get(int id) {
            return Context.Supply.SingleOrDefault(supply => supply.Id == id);
        }

        public IEnumerable<SupplyFlower> GetSupplyFlowers(int id) {
            return Context.Supply.SingleOrDefault(supply => supply.Id == id).SupplyFlowers;
        }

        public void UpdateSupplyFlower(SupplyFlower supplyFlower) {
            Context.SupplyFlowers.Update(supplyFlower);
        }
    }
}
