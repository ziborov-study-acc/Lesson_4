using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary
{
    public class Flower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="Название цветка")]
        [Required(ErrorMessage ="Введите название цветка")]
        [StringLength(100,ErrorMessage ="Количество символом больше 100!")]
        public string Name { get; set; }

        [Display(Name = "Название цветка на латинице")]
        [Required(ErrorMessage = "Введите название цветка на латинице")]
        [StringLength(100, ErrorMessage = "Количество символом больше 100!")]
        public string LatinName { get; set; }
    }
}