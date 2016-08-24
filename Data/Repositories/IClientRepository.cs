using System.Collections.Generic;
using Models;

namespace Data.Repositories
{
    public interface IClientRepository
    {
        IList<Client> LoadClients();
        void CreateClient(Client client);
        void DeleteClient(int id);
        void UpdateClient(Client client);
    }
}
