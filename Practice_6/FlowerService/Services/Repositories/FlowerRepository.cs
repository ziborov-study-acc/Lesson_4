using FlowerService.Services.Interfaces;
using FlowerServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Repositories {
    public class FlowerRepository : RepositoryBase<Flower>, IFlowerRepository {
        public FlowerRepository(FlowerServiceContext context) : base(context) {
        }

        public Flower Get(int id) {
            return Context.Flowers.SingleOrDefault(flower => flower.Id == id);
        }
    }
}
