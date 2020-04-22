using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerServiceLibrary {
    public abstract class Place
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "���������� �������� ������ 100!")]
        public string Name { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "���������� �������� ������ 500!")]
        public string Address { get; set; }

    }
}