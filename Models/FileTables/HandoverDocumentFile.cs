using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class HandoverDocumentFile
    {
        public Guid HandoverDocumentId { get; set; }
        public HandoverDocument HandoverDocument { get; set; }
        public Guid FileDescriptionId { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
