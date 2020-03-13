﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ClientFile
    {
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
        public Guid FileDescriptionId { get; set; }
        public FileDescription FileDescription { get; set; }
    }
}
