using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IServiceFacilitiesRepository
    {
        ServiceFacility GetServiceFacility(Guid id);
        IEnumerable<ServiceFacility> GetAll();
        ServiceFacility Update(ServiceFacility serviceFacilityChanges);
        ServiceFacility Add(ServiceFacility serviceFacility);
        ServiceFacility Delete(ServiceFacility serviceFacility);
    }
}
