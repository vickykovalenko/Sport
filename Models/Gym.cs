using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sport
{
    public partial class Gym
    {
        public Gym()
        {
            Passes = new HashSet<Pass>();
        }

        public int Id { get; set; }
        [Display(Name = "Назва залу")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [StringLength(20)]
        [RegularExpression(@"^[А-Яа-яёЁЇїІіЄєҐґ]+", ErrorMessage = "Поле має містити лише букви")]

        public string Name { get; set; }
        [Display(Name = "Опис")]
        [StringLength(50)]
        [RegularExpression(@"^[А-Яа-яёЁЇїІіЄєҐґ]+", ErrorMessage = "Поле має містити лише букви")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]


        public string Description { get; set; }
      
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Поле має містити лише цифри")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Площа")]
        public decimal? Area { get; set; }

        public virtual ICollection<Pass> Passes { get; set; }
    }
}
