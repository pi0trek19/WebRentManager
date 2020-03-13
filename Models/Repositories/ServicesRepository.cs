using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ServicesRepository : IServicesRepository
    {
        private readonly AppDbContext context;
        public ServicesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Service Add(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();
            return service;

        }

        public IEnumerable<Service> GetAll()
        {
            return context.Services;
        }

        public IEnumerable<Service> GetAllbyFacility(Guid facilityId)
        {
            return context.Services.AsQueryable().Where(service => service.ClientId == facilityId).ToList();
        }

        public IEnumerable<Service> GetAllbyCar(Guid carId)
        {
            return context.Services.AsQueryable().Where(service => service.CarId == carId).ToList();
        }

        public Service Remove(Service service)
        {
            throw new NotImplementedException();
        }

        public Service Upadate(Service serviceChanges)
        {
            throw new NotImplementedException();
        }

        public Service GetService(Guid Id)
        {
            return context.Services.Find(Id);
        }
    }
}
