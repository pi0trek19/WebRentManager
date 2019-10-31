using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public enum CostCategory
    {
        
        Przegląd,
        Serwis,
        Naprawa,
        [DisplayName("Zakup opon")]
        ZakupOpon,
        [DisplayName("Wymiana opon")]
        WymianaOpon,
    }
}
