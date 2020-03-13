using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class RentFormModalViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Typ uszkodzenia")]
        public DamageType DamageType { get; set; }
        [DisplayName("Opis uszkodzenia")]
        [Required]
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }
}
