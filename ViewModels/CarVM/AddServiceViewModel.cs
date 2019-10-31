﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class AddServiceViewModel
    {
        public List<ServiceFacility> ServiceFacilities { get; set; }
        public Car Car { get; set; }
        public Guid Id { get; set; }
        [Required]
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [Required]
        [DisplayName("Przebieg")]
        public int Milage { get; set; }

        [DisplayName("Seriws")]
        public ServiceFacility ServiceFacility { get; set; }
        [Required]
        [DisplayName("Serws")]
        public Guid ServiceFacilityId { get; set; }
        [DisplayName("Typ serwisu")]
        public ServiceType ServiceType { get; set; }
        public Guid CarId { get; set; }
        [DisplayName("Kwota")]
        public decimal Cost { get; set; }
        public IFormFile Invoice { get; set; }
    }
}