using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class FinishedRentDetails
    {
        public Guid Id { get; set; }
        public Guid RentId { get; set; }
        public int EndMilage { get; set; }
        public int TotalMilage { get; set; }
        public bool IsOverMilage { get; set; }
        public int OverMilage { get; set; }
        public decimal OverMilageFee { get; set; }
    }
}
