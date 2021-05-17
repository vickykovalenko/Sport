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
        public string Description { get; set; }
        [Display(Name = "Ціна")]
        [RegularExpression(@"^[0-9][0-9]{1,6}$", ErrorMessage = "Некоректна довжина")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public decimal? Price { get; set; }
        public int GymId { get; set; }

        public virtual Gym Gym { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
