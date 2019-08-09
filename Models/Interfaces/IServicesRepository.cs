using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IServicesRepository
    {
        IEnumerable<Service> GetAll();
        IEnumerable<Service> GetAllbyFacility(Guid facilityId);
        IEnumerable<Service> GetAllbyCar(Guid carId);
        Service GetService(Guid Id);
        Service Add(Service service);
        Service Upadate(Service serviceChanges);
        Service Remove(Service service);
    }
}
