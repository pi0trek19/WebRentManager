using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public interface IClientsRepository
    {
        Client Add(Client client);
        Client GetClient(Guid id);
        IEnumerable<Client> GetAllClients();
        Client Update(Client clientChanges);

    }
}
