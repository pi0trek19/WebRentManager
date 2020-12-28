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
    public class InsuranceClaimsAddClaimFileViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public IFormFile File { get; set; }
        [Required]
        [DisplayName("Typ pliku")]
        public FileType FileType { get; set; }
        [DisplayName("Opis")]
        public string Descrption { get; set; }
    }
}
