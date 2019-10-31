using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebRentManager.Models
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly AppDbContext context;

        public ClientsRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Client Add(Client client)
        {
            context.Clients.Add(client);
            context.SaveChanges();
            return client;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return context.Clients;
        }

        public Client GetClient(Guid id)
        {
            return context.Clients.Find(id);
       }

        public Client Update(Client clientChanges)
        {
            throw new NotImplementedException();
        }
    }
}
