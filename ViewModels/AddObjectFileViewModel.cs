using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class AddObjectFileViewModel
    {
        public Guid Id { get; set; } //object id;
        public string Controller { get; set; }
        public string Action { get; set; }
        public IFormFile FormFile { get; set; }
        public FileType FileType { get; set; }
        public string Description { get; set; }

    }
}
