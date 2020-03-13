using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.ViewModels
{
    public class MailMessageCreateViewModel
    {
        [Required]
        [DisplayName("Opis")]
        public string Desc { get; set; }
        [Required]
        [DisplayName("Temat")]
        public string Subject { get; set; }
        [Required]
        [DisplayName("Treść maila")]
        public string Content { get; set; }
    }
}
