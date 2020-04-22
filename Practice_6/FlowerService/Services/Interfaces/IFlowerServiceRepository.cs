using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.Services.Interfaces {
    public interface IFlowerServiceRepository {
        IFlowerRepository FlowerRepository { get; }
        IPlantationRepository PlantationRepository { get; }
        IWarehouseRepository WarehouseRepository { get; }

        void SaveChanges();
    }
}
