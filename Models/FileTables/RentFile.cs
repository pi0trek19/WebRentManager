using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class RentFile
    {
        public Guid RentId { get; set; }
        public Rent Rent { get; set; }
        public Guid FileDescriptionId { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
