﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sport
{
    public partial class Trainer
    {
        public Trainer()
        {
            Clients = new HashSet<Client>();
        }
        private const string reg_email = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        public int Id { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [StringLength(50)]

        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [StringLength(50)]

        public string Surname { get; set; }
        [Display(Name = "Заробітня плата")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@"^[0-9][0-9]{4,6}$", ErrorMessage = "Некоректна довжина")]

        public decimal Salary { get; set; }
        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [RegularExpression(@"^[0-9][0-9]{4,6}$", ErrorMessage = "Некоректна довжина")]
        public string Phone { get; set; }
        [Display(Name = "Електронна пошта")]
        [RegularExpression(reg_email, ErrorMessage = "Некоректна електронна пошта")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        public string Email { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
