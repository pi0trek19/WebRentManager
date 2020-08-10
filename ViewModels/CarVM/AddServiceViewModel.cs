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
    public class AddServiceViewModel
    {
        public List<Client> ServiceFacilities { get; set; }
        public Car Car { get; set; }
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Przebieg")]
        public int Milage { get; set; }

        [DisplayName("Seriws")]
        public Client ServiceFacility { get; set; }
        [Required]
        [DisplayName("Serws")]
        public Guid ServiceFacilityId { get; set; }
        [DisplayName("Typ serwisu")]
        public ServiceType ServiceType { get; set; }
        public Guid CarId { get; set; }
        [Required]
        [DisplayName("Kwota")]
        public decimal Cost { get; set; }
        //faktura
        [DisplayName("Dodaj fakturę")]
        public bool IsInvoiceAdded { get; set; }
        [DisplayName("Numer faktury")]
        public string Number { get; set; }
        //dodać przesyłanie pliku
        public IFormFile File { get; set; }
    }
}
