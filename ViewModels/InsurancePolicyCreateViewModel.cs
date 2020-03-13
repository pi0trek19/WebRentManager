using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class InsurancePolicyCreateViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        [Required]
        [Display(Name="Ważność od")]
        public DateTime ValidFrom { get; set; }
        [Required]
        [Display(Name = "Ważność do")]
        public DateTime ValidTo { get; set; }
        [Display(Name = "Suma składek [netto]")]
        public decimal Cost { get; set; }
        [Required]
        [Display(Name = "Numer polisy")]
        public string Number { get; set; }
        [Required]
        [Display(Name = "TU")]
        public string InsuranceCompany { get; set; }
    }
}
