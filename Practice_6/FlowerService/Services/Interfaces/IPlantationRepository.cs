using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Interfaces {
    public interface IPlantationRepository : IRepositoryBase<Plantation> {
        Plantation Get(int id);

        void CreatePlantationFlower(PlantationFlower plantationFlower);
        void UpdatePlantationFlower(PlantationFlower plantationFlower);
        void DeletePlantationFlower(PlantationFlower plantationFlower);
        IEnumerable<PlantationFlower> GetPlantationFlowers(int id);
    }
}
