using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarExpenseFile
    {
        public Guid CarExpenseId { get; set; }
        public CarExpense CarExpense { get; set; }
        public Guid FileDescriptionId { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
