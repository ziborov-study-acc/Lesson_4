using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public class SupplyFlower
    {
        [Display(Name = "����� ��������")]
        [ForeignKey("Supply")]
        public int SupplyId { get; set; }
        public virtual Supply Supply { get; set; }

        [Display(Name = "������")]
        [ForeignKey("Flower")] 
        public int FlowerId { get; set; }
        public virtual Flower Flower { get; set; }

        [Display(Name = "����������")]
        [Range(0, int.MaxValue, ErrorMessage = "���������� �� ����� ���� �������������")]
        public int Amount { get; set; }
    }
    
}