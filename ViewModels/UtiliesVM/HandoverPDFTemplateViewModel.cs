using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class HandoverPDFTemplateViewModel
    {
        public string ClientName { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserMail { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarReg { get; set; }
        public FuelType FuelType { get; set; }
        public string RentingCompany { get; set; }

        //wydanie:
        public DateTime StartDate { get; set; }
        public int StartFuel { get; set; }
        public int StartMilage { get; set; }
        public string StartNotes { get; set; }



        //zdanie
        public DateTime EndDate { get; set; }
        public int EndFuel { get; set; }
        public int EndMilage { get; set; }
        public string EndNotes { get; set; }

        public List<CarDamage> CarDamages { get; set; }


    }
}
