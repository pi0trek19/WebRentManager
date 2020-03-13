using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class CarCreateViewModel
    {
        [Required]
        [DisplayName("Nr rejestracyjny")]
        public string RegistrationNumber { get; set; }
        [Required]
        [DisplayName("Marka")]
        public string Make { get; set; }
        [Required]
        [DisplayName("Model")]
        public string Model { get; set; }
        [Required]
        [DisplayName("Rok produkcji")]        
        public int ProductionYear { get; set; }
        [DisplayName("VIN")]
        public string VIN { get; set; }
        [DisplayName("Przebieg")]
        public int Milage { get; set; }
        [DisplayName("Okres przeglądów")]
        public int ServiceInterval { get; set; }
        [DisplayName("Data pierwszej rej")]
        public DateTime RegistrationDate { get; set; }
        [DisplayName("Moc KM")]
        public int PowerHP { get; set; }
        [DisplayName("Moc kW")]
        public int PowerkW { get; set; }
        [DisplayName("Poj. skokowa cm3")]
        public int EngineSize { get; set; }
        [DisplayName("Typ nadwozia")]
        public BodyType BodyType { get; set; }
        [DisplayName("Typ paliwa")]
        public FuelType FuelType { get; set; }
        [DisplayName("Typ skrzyni")]
        public GearboxType GearboxType { get; set; }
        [DisplayName("Kolor")]
        public string Color { get; set; }
        [DisplayName("Wersja wyposażenia")]
        public string SpecType { get; set; }
    }
}
