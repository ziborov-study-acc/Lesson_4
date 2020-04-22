using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public abstract class PlaceFlower<T> where T : Place
    {
        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public virtual T Place { get; set; }
        
        [ForeignKey("Flower")] 
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }
    
        [Range(0,int.MaxValue,ErrorMessage =" оличество не может быть отрицательным")]
        public int Amount { get; set; }
        
    }
}