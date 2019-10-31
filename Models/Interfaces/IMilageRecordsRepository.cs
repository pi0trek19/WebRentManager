﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IMilageRecordsRepository
    {
        MilageRecord Add(MilageRecord record);
        IEnumerable<MilageRecord> GetMilageRecordsByCar(Guid carId);

    }
}
