using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class ReportsGeneralReportViewModel
    {
        public List<string> DropdownItems { get; set; }
        [DisplayName("Typ danych")]
        public string SelectedItem { get; set; }
    }
}
