using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarDamageFile
    {
        public CarDamage CarDamage { get; set; }
        public Guid CarDamageId { get; set; }
        public FileDescription FileDescription { get; set; }
        public Guid FileDescriptionId { get; set; }
    }
}
