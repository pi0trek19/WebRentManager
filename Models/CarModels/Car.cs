using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class Car
    {
        //public bool Enabled { get; set; }
        public Guid Id { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsReserved { get; set; }
        public DateTime ReservedUntil { get; set; }
        [DisplayName("Nr rejestracyjny")]
        public string RegistrationNumber { get; set; }
        [DisplayName("VIN")]
        public string VIN { get; set; }
        [DisplayName("Marka")]
        public string Make { get; set; }
        [DisplayName("Model")]
        public string Model { get; set; }
        [DisplayName("Rok Produkcji")]
        public int ProductionYear { get; set; }
        [DisplayName("Przebieg")]
        public int Milage { get; set; }
        [DisplayName("Okres przeglądów")]
        public int ServiceInterval { get; set; }
        [DisplayName("Czas pomiędzy przeglądami")]
        public int YearsServiceInterval { get; set; }
        [DisplayName("Następny serwis")]
        public int NextServiceMilage { get; set; }
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
        [DisplayName("Nast. badanie techniczne")]
        public DateTime NextTechCheckDate { get; set; }
        [DisplayName("Kolor")]
        public string Color { get; set; }
        [DisplayName("Wersja wyposażenia")]
        public string SpecType { get; set; }
        public List<Service> Services { get; set; }
        public List<TyreInfo> TyreInfos { get; set; }
        public FinancialInfo FinancialInfo { get; set; }
        public List<MilageRecord> MilageHistory { get; set; }
        public List<CarFile> CarFiles { get; set; }
    }
}
