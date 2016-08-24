using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Data.Repositories;
using Models;

namespace Data
{
    public class ClientsContext : DbContext, IClientRepository
    {
        public ClientsContext()
            : base("DefaultConnection")
        {}

        public virtual DbSet<Client> Clients { get; set; }

        public IList<Client> LoadClients()
        {
            return Clients.ToList();
        }

        public void CreateClient(Client client)
        {
            Clients.Add(client);
            SaveChanges();
        }

        public void DeleteClient(int id)
        {
            var client = Clients.Find(id);
            if (client != null)
            {
                Clients.Remove(client);
            }
        }

        public void UpdateClient(Client client)
        {
            Clients.Attach(client);
            Entry(client).State = EntityState.Modified;
            SaveChanges();
        }
    }
}
