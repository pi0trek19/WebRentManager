using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        //public bool IsAvailable { get; set; }
        //public bool Enabled { get; set; }
        [DisplayName("Nr rejestracyjny")]
        public string RegistrationNumber { get; set; }
        //public string VIN { get; set; }
        [DisplayName("Marka")]
        public string Make { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Rok Produkcji")]
        public int ProductionYear { get; set; }
        //public int Milage { get; set; }
        //public int NextServiceMilage { get; set; }
        //public DateTime RegistrationDate { get; set; }
        //public int PowerHP { get; set; }
        //public int PowerkW { get; set; }
        //public int EngineSize { get; set; }
        //public string BodyType { get; set; }
        //public string FuelType { get; set; }
        //public string GearboxType { get; set; }
        //public DateTime NextTechCheckDate { get; set; }


    }
}
