using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sport
{
    public partial class Payment
    {
        public int Id { get; set; }
        [Display(Name = "Id клієнта")]
        public int ClientId { get; set; }
        [Display(Name = "Id абонемента")]
        public int PassesId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [StringLength(20)]
        [Display(Name = "Місяць")]
        [RegularExpression(@"^[А-Яа-яёЁЇїІіЄєҐґ]+", ErrorMessage = "Поле має містити лише букви")]

        public string Month { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Стан оплати")]
        [StringLength(5)]
        [RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Поле має містити лише англійські букви")]


        public bool? IsPaymentDone { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Сума")]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Поле має містити лише цифри")]
        public decimal? Sum { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер картки клієнта")]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Поле має містити лише цифри")]

        public string ClCardNumber { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер картки компанії")]
        [RegularExpression(@"^[0-9]+", ErrorMessage = "Поле має містити лише цифри")]

        public string CompanyCardNumber { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Чи є переплата")]
        [StringLength(5)]
        [RegularExpression(@"^[a-zA-Z]+", ErrorMessage = "Поле має містити лише англійські букви")]

        public bool? IsOverPay { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Чи є борг")]

        public bool IsDebt { get; set; }

        public virtual Client Client { get; set; }
        public virtual Pass Passes { get; set; }
    }
}
