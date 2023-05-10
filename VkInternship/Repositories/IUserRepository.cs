using VkInternship.Models;

namespace VkInternship.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> Get(int id);
        Task Create(User user);
        Task Delete(int id);
        Task<bool> AnyLogin(string login);
        Task<bool> AnyAdmin();
    }
}
