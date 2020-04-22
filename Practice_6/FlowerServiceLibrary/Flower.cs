using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary
{
    public class Flower
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="�������� ������")]
        [Required(ErrorMessage ="������� �������� ������")]
        [StringLength(100,ErrorMessage ="���������� �������� ������ 100!")]
        public string Name { get; set; }

        [Display(Name = "�������� ������ �� ��������")]
        [Required(ErrorMessage = "������� �������� ������ �� ��������")]
        [StringLength(100, ErrorMessage = "���������� �������� ������ 100!")]
        public string LatinName { get; set; }
    }
}