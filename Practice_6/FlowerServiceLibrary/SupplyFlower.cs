using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public class SupplyFlower
    {
        [Display(Name = "Номер поставки")]
        [ForeignKey("Supply")]
        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }

        [Display(Name = "Цветок")]
        [ForeignKey("Flower")] 
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }

        [Display(Name = "Количество")]
        [Range(0, int.MaxValue, ErrorMessage = "Количество не может быть отрицательным")]
        public int Amount { get; set; }
    }
    
}