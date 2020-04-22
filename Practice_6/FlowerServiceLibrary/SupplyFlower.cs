using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public class SupplyFlower
    {
        [ForeignKey("Supply")]
        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }
        
        [ForeignKey("Flower")] 
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = " оличество не может быть отрицательным")]
        public int Amount { get; set; }
    }
    
}