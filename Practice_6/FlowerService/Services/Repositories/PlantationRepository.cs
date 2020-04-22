using FlowerService.Services.Interfaces;
using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Repositories {
    public class PlantationRepository : RepositoryBase<Plantation>, IPlantationRepository {
        public PlantationRepository(FlowerServiceContext context) : base(context) {
        }

        public void CreatePlantationFlower(PlantationFlower plantationFlower) {
            Context.Plantations.SingleOrDefault(plantation => plantation.Id == plantationFlower.PlaceId).PlantationFlowers.Add(plantationFlower);            //Context.PlantationFlowers.Add(plantationFlower);
        }

        public void DeletePlantationFlower(PlantationFlower plantationFlower) {
            Context.Plantations.SingleOrDefault(plantation => plantation.Id == plantationFlower.PlaceId).PlantationFlowers.Remove(plantationFlower);
        }

        public Plantation Get(int id) {
            return Context.Plantations.SingleOrDefault(plantation => plantation.Id == id);
        }

        public IEnumerable<PlantationFlower> GetPlantationFlowers(int id) {
            return Context.Plantations.SingleOrDefault(plantation => plantation.Id == id).PlantationFlowers;
        }

        public void UpdatePlantationFlower(PlantationFlower plantationFlower) {
            Context.PlantationFlowers.Update(plantationFlower);
        }
    }
}
