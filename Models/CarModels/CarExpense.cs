using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarExpense
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public CostCategory CostCategory { get; set; }
        public decimal Amount { get; set; }
        public string Decription { get; set; }
        public Guid FacilityId { get; set; }
        public DateTime Date { get; set; }
        public List<CarExpenseFile> CarExpenseFiles { get; set; }

    }
}
