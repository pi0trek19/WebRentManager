using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class MailMessage
    {
        public bool Enabled { get; set; }
        public Guid Id { get; set; }
        public string Desc { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
