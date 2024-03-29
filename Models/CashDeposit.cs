﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class CashDeposit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal CurrentAmount { get; set; }
        public List<CashDepositAction> DepositActions { get; set; }

    }
}
