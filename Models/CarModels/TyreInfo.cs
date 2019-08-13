using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class TyreInfo
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid TyreShopId { get; set; }
        public Car Car { get; set; }
        public TyreShop TyreShop { get; set; }
        public string TyreName { get; set; }
        public int Diameter { get; set; }
        public int Profile { get; set; }
        public int Width { get; set; }
        public string SpeedIndex { get; set; }
        public int Dot { get; set; }

    }
}
