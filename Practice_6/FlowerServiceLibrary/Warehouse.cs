using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public class Warehouse : Place
    {
        public virtual ICollection<WarehouseFlower> WarehouseFlowers { get; set; }
    }
}