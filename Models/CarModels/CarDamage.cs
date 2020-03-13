using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarDamage
    { 
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public DamageType DamageType { get; set; }
        public string Description { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }        
        public Guid RentId { get; set; }
        public bool IsEndDamage { get; set; }
        public DateTime DateMarked { get; set; }
        public List<CarDamageFile> CarDamageFiles { get; set; }

    }
}
