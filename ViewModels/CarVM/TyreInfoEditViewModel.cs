using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class TyreInfoEditViewModel
    {
        public Guid Id { get; set; }
        public Guid CarId { get; set; }

        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane")]
        public string TyreName { get; set; }

        [Range(13, 25)]
        [DisplayName("Średnica")]
        [Required(ErrorMessage = "Pole Średnica jest wymagane")]
        public int Diameter { get; set; }

        [Range(25, 75)]
        [DisplayName("Profil")]
        [Required(ErrorMessage = "Pole Profil jest wymagane")]
        public int Profile { get; set; }

        [Range(165, 355)]
        [DisplayName("Szerokość")]
        [Required(ErrorMessage = "Pole Szerokość jest wymagane")]
        public int Width { get; set; }

        [DisplayName("Indeks prędkości")]
        [Required(ErrorMessage = "Pole Indeks prędkości jest wymagane")]
        public string SpeedIndex { get; set; }
        [DisplayName("DOT")]
        public int Dot { get; set; }
        [DisplayName("Typ opony")]
        public TyreType TyreType { get; set; }
    }
}
