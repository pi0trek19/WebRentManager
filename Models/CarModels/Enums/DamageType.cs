using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public enum DamageType
    {
        Rysa,
        Odprysk,
        Otarcie,
        BrakujacyElement,
        Wgniecenie,
        Plama,
        Zabrudzenie
    }
}
