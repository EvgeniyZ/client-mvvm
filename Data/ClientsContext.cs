using System.Data.Entity;
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

        public int CreateClient(Client client)
        {
            Clients.Add(client);
            SaveChanges();

            return client.Id;
        }

        public void DeleteClient(int id)
        {
            var client = Clients.Find(id);
            if (client != null)
            {
                Clients.Remove(client);
                SaveChanges();
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
