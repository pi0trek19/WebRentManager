using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IRentsRepository
    {
        Rent Add(Rent rent);
        Rent GetRent(Guid id);
        IEnumerable<Rent> GetAllRents();
        IEnumerable<Rent> GetAllReservations();
        IEnumerable<Rent> GetAllFinished();
        IEnumerable<Rent> GetAllRentsByCar(Guid carId);
        IEnumerable<Rent> GetAllRentsByClient(Guid clientId);
        Rent Update(Rent rentChanges);

    }
}
