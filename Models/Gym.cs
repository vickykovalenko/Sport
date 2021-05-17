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
        public string Name { get; set; }
        [Display(Name = "Опис")]
        [StringLength(50)]


        public string Description { get; set; }
        [StringLength(20)]
        [RegularExpression(@"^[0-9][0-9]{1,6}$", ErrorMessage = "Некоректна довжина")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Площа")]
        public decimal? Area { get; set; }

        public virtual ICollection<Pass> Passes { get; set; }
    }
}
