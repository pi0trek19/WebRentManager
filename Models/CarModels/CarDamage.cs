using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CarDamage
    {
        public Guid CarId { get; set; }
        public Guid Id { get; set; }
        public DamageType DamageType { get; set; }
        public string Description { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public Guid PhotoId { get; set; }
    }
}
