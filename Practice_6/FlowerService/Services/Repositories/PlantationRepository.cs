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

        public Plantation Get(int id) {
            return Context.Plantations.SingleOrDefault(plantation => plantation.Id == id);
        }
    }
}
