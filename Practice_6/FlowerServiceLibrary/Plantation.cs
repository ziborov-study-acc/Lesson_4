using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public class Plantation : Place
    {
        public virtual ICollection<PlantationFlower> PlantationFlowers { get; set; }
    }
}