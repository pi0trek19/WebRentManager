using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class CarExpenseAddViewModel
    {
        public Guid CarId { get; set; }
        [Required]
        [DisplayName("Kategoria")]
        public CostCategory CostCategory { get; set; }
        [Required]
        [DisplayName("Kwota")]
        public decimal Amount { get; set; }
        [DisplayName("Opis")]
        public string Decription { get; set; }
        [DisplayName("Wybieram serwis")]
        public bool IsServiceSelected { get; set; }
        [DisplayName("Serwis")]
        public Guid FacilityId { get; set; }
        [Required]
        [DisplayName("Data")]
        public DateTime Date { get; set; }
    }
}
