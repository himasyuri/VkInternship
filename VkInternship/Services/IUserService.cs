using VkInternship.Models;
using VkInternship.Requests;

namespace VkInternship.Services
{
    public interface IUserService
    {
        public ValueTask<User> Get(int userId);

        public ValueTask<PagedListService<User>> GetAll(AllUsersParametersRequest request);

        public ValueTask<User> Create(AddUserRequest request);

        public ValueTask Delete(int userId);
    }
}
