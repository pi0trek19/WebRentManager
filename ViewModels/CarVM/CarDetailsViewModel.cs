using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class CarDetailsViewModel
    {
        public Car Car { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<TyreInfo> TyreInfos { get; set; }
        public IEnumerable<MilageRecord> MilageHistory { get; set; }
        public FinancialInfo FinancialInfo { get; set; }
        public string PageTitle { get; set; }
    }
}
