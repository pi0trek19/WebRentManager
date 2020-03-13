using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class FileDescription
    {
        public bool Enabled { get; set; }
        public Guid Id { get; set; }  //jednocześnie nazwa pliku na S3
        public string Ext { get; set; } //rozszerzenie, zapisujemy same nazwy bez rozszerzeń, podczas obróbki dodajemy i zmieniamy nazwę
        public FileType FileType { get; set; }
        public string FileName { get; set; } //nazwa jaką nadajemy plikowi u nas, ustandaryzowana podczas wrzucania na serwer
        public string Description { get; set; } 
        public DateTime DateAdded { get; set; }
        public List<CarFile> CarFiles { get; set; } 
        public List<ClientFile> ClientFiles { get; set; }  
        public List<RentFile> RentFiles { get; set; } 
        public List<HandoverDocumentFile> HandoverDocumentFiles { get; set; } 
        public List<InsuranceClaimFile> InsuranceClaimFiles { get; set; } 
        public List<ServiceFile> ServiceFiles { get; set; } 
        public List<CarExpenseFile> CarExpenseFiles { get; set; } 
        public List<CarDamageFile> CarDamageFiles { get; set; }
        public List<InsurancePolicyFile> InsurancePolicyFiles { get; set; }
    }
}
