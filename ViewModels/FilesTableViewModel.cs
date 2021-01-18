using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebRentManager.Models;

namespace WebRentManager.ViewModels
{
    public class FilesTableViewModel
    {
        public List<Tuple<FileDescription, string, Guid>> List { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public Guid ItemId { get; set; }
    }
}
