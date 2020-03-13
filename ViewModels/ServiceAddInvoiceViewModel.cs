using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class ServiceAddInvoiceViewModel
    {
        public Guid ServiceId { get; set; }
        [Required]
        [DisplayName("Numer faktury")]
        public string Number { get; set; }
    }
}
