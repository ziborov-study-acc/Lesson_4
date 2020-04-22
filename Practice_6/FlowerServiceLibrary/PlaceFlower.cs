using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public abstract class PlaceFlower<T> where T : Place
    {
        [Display(Name ="Плантация")]
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public virtual T Place { get; set; }
        
        [Display(Name ="Цветок")]
        [ForeignKey("Flower")] 
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }
    
        [Required]
        [Display(Name ="Количество")]
        [Range(0,int.MaxValue,ErrorMessage ="Количество не может быть отрицательным")]
        public int Amount { get; set; }
        
    }
}