﻿using System;
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


        public string Name { get; set; }
        [Display(Name = "Прізвище")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]

        public string Surname { get; set; }
        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]


        public string Phone { get; set; }
        [RegularExpression(reg_email, ErrorMessage = "Некоректна електронна пошта")]
        [Display(Name = "Електронна пошта")]
        [Required(ErrorMessage = "Поле не повинно бути порожнім ")]
        [StringLength(30)]

        public string Email { get; set; }
        [Display(Name = "Тренер")]
                

        public int? TrainerId { get; set; }
        [Display(Name = "Тренер")]

        public virtual Trainer Trainer { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}