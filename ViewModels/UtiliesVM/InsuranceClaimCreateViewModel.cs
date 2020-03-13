using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class InsuranceClaimCreateViewModel
    {
        public Guid Id { get; set; }
        public string CarReg { get; set; }
        public Guid CarId { get; set; }
        [DisplayName("Nazwa TU")]
        [Required]
        public string InsuranceCompany { get; set; }
        [DisplayName("Data szkody")]
        [Required]
        public DateTime ClaimDate { get; set; }
        [DisplayName("Data zgłoszenia")]
        [Required]
        public DateTime ReportDate { get; set; }
        [DisplayName("Imię i nazwisko likwidatora")]
        public string RepresentativeName { get; set; }
        [DisplayName("Telefon likwidatora")]
        public string RepresentativePhone { get; set; }
        [DisplayName("E-mail likwidatora")]
        public string RepresentativeMail { get; set; }
        [DisplayName("Nr szkody")]
        [Required]
        public string ClaimNo { get; set; }
        [DisplayName("Typ szkody")]
        public ClaimType ClaimType { get; set; }
    }
}
