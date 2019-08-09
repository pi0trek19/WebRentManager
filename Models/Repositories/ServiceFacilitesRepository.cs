using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ServiceFacilitesRepository : IServiceFacilitiesRepository
    {
        private readonly AppDbContext context;
        public ServiceFacilitesRepository(AppDbContext context)
        {
            this.context = context;
        }
        public ServiceFacility Add(ServiceFacility serviceFacility)
        {
            context.ServiceFacilities.Add(serviceFacility);
            context.SaveChanges();
            return serviceFacility;
        }

        public ServiceFacility Delete(ServiceFacility serviceFacility)
        {
            context.ServiceFacilities.Remove(serviceFacility);
            return serviceFacility;
        }

        public IEnumerable<ServiceFacility> GetAll()
        {
            return context.ServiceFacilities;
        }

        public ServiceFacility GetServiceFacility(Guid id)
        {
            return context.ServiceFacilities.Find(id);
        }

        public ServiceFacility Update(ServiceFacility serviceFacilityChanges)
        {
            var serviceFacility = context.ServiceFacilities.Attach(serviceFacilityChanges);
            serviceFacility.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return serviceFacilityChanges;
        }
    }
}
