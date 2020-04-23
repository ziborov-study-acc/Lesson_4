using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;

namespace FlowerServiceLibrary {
    public class Supply
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name ="���������")]
        [Required]
        [ForeignKey("Plantation")]
        public int PlantationId { get; set; }
        public virtual Plantation Plantation { get; set; }

        [Display(Name = "�����")]
        [Required]
        [ForeignKey("Warehouse")]
        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        
        [Display(Name ="����������� ���� ��������")]
        public DateTime? SheduledDate { get; set; }
        [Display(Name = "�������� ���� ��������")]
        public DateTime? ClosedDate { get; set; }

        [Display(Name = "������ ��������")]
        [Required]
        [StringLength(40)]
        public string Status { get; set; }

        public virtual ICollection<SupplyFlower> SupplyFlowers { get; set; }
    }
}