using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class MilageRecordsRepository : IMilageRecordsRepository
    {
        private readonly AppDbContext context;

        public MilageRecordsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public MilageRecord Add(MilageRecord record)
        {
            context.MilageRecords.Add(record);
            context.SaveChanges();
            return record;
        }

        public IEnumerable<MilageRecord> GetMilageRecordsByCar(Guid carId)
        {
            return context.MilageRecords.Where(record => record.CarId == carId);
        }
    }
}
