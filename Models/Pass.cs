using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sport
{
    public partial class Pass
    {
        public Pass()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        [Display(Name = "Вид абонементу")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@"^[А-Яа-яёЁЇїІіЄєҐґ]+", ErrorMessage = "Поле має містити лише букви")]

        public string Description { get; set; }
        [Display(Name = "Ціна")]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Поле має містити лише цифри")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public decimal? Price { get; set; }
        [Display(Name = "Зал")]

        public int GymId { get; set; }

        public virtual Gym Gym { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
