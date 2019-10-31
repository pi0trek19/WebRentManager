using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class RentsRepository : IRentsRepository
    {
        private readonly AppDbContext context;

        public RentsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Rent Add(Rent rent)
        {
            context.Rents.Add(rent);
            context.SaveChanges();
            return rent;
        }

        public IEnumerable<Rent> GetAllFinished()
        {
            return context.Rents.Where(rent => rent.IsFinished == true);
        }

        public IEnumerable<Rent> GetAllRents()
        {
            return context.Rents.Where(rent=>rent.IsActive==true && rent.IsFinished==false);
        }

        public IEnumerable<Rent> GetAllRentsByCar(Guid carId)
        {
            return context.Rents.Where(rent => rent.CarId == carId);
        }

        public IEnumerable<Rent> GetAllRentsByClient(Guid clientId)
        {
            return context.Rents.Where(rent => rent.ClientId == clientId);
        }

        public IEnumerable<Rent> GetAllReservations()
        {
            return context.Rents.Where(rent => rent.IsActive == false);
        }

        public Rent GetRent(Guid id)
        {
            return context.Rents.Find(id);
        }

        public Rent Update(Rent rentChanges)
        {
            var rent = context.Rents.Attach(rentChanges);
            rent.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return rentChanges;
        }
    }
}
