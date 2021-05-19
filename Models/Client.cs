using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sport
{
    public partial class Client
    {
        private const string reg_email = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public Client()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]
        [RegularExpression(@"^[А-Яа-яёЁЇїІіЄєҐґ]+", ErrorMessage = "Поле має містити лише букви")]
        [StringLength(50)]



        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]
        [RegularExpression(@"^[А-Яа-яёЁЇїІіЄєҐґ]+", ErrorMessage = "Поле має містити лише букви")]
        [StringLength(50)]




        public string Surname { get; set; }
        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]
        [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Поле має містити лише цифри")]


        public string Phone { get; set; }
        [Display(Name = "Електронна пошта")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]

        public string Email { get; set; }
        [Display(Name = "Тренер")]
                

        public int? TrainerId { get; set; }
        [Display(Name = "Тренер")]

        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
