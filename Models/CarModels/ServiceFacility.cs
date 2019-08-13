using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ServiceFacility
    {
        public Guid Id { get; set; }
        [DisplayName("Nazwa")]
        public string Name { get; set; }
        [DisplayName("Ulica")]
        public string Street { get; set; }
        [DisplayName("Kod Pocztowy")]
        public string ZipCode { get; set; }
        [DisplayName("Miasto")]
        public string City { get; set; }

    }
}
