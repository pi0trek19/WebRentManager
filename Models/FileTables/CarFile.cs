using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarFile
    {
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid FileDescriptionId { get; set; }       
        public FileDescription FileDescription { get; set; }
    }
}
