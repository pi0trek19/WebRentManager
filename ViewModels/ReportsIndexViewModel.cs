using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class ReportsIndexViewModel
    {
        public List<CheckboxItem> CheckboxItems { get; set; }
    }
    public class CheckboxItem
    {
        public Guid Id { get; set; }
        public string Entity { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }
}
