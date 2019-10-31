using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class MilageRecord
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public DateTime Date { get; set; }
        public int Milage { get; set; }
    }
}
