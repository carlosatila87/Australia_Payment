using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AustraliaPayment.Models
{
    public class Payment
    {
        [Required(ErrorMessage = "BSB is mandatory.")]
        [Display(Name = "BSB")]
        public string BSB { get; set; }

        [Required(ErrorMessage = "Account Number is mandatory.")]
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Account Name is mandatory.")]
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        
        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Required(ErrorMessage = "Amount is mandatory.")]
        [Display(Name = "Amount")]
        public decimal Amount { get; set; }
    }
}