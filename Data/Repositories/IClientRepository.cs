using Models;

namespace Data.Repositories
{
    public interface IClientRepository
    {
        int CreateClient(Client client);
        void DeleteClient(int id);
        void UpdateClient(Client client);
    }
}
