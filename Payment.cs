using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Sport
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int PassesId { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [StringLength(50)]
        [Display(Name = "Місяць")]
        public string Month { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Стан оплати")]
        public bool? IsPaymentDone { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Сума")]
        public decimal? Sum { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер картки клієнта")]
        public string ClCardNumber { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер картки компанії")]
        public string CompanyCardNumber { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Чи є переплата")]
        public bool? IsOverPay { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Чи є борг")]
        public bool IsDebt { get; set; }

        public virtual Client Client { get; set; }
        public virtual Pass Passes { get; set; }
    }
}
