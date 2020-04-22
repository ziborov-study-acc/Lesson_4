using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FlowerService.ViewModels {
    public class PlantationFlowerViewModel {

        [Required]
        public int PlantationId { get; set; }

        [Display(Name ="Цветок")]
        public int FlowerId { get; set; }
        [Display(Name ="Количество")]
        [Range(0,int.MaxValue,ErrorMessage ="Количество должно быть больше нуля")]
        public int Amount { get; set; }

    }
}
