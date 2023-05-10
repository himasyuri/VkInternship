using VkInternship.Models;
using VkInternship.Repositories;
using VkInternship.Requests;

namespace VkInternship.Services
{
    public class UserService : IUserService
    {
        private readonly UnitOfWork unitOfWork;

        public UserService()
        {
            unitOfWork = new UnitOfWork();
        }

        public async ValueTask<User> Create(AddUserRequest request)
        {
            if (await CheckLogin(request.Login))
            {
                throw new Exception($"User with this login {request.Login} already exist");
            }

            if (request.GroupCode != "User" || request.GroupCode != "Admin")
            {
                if (request.GroupCode == "Admin" && await CheckGroupCode())
                {
                    throw new Exception("Only one admin");
                }
            }

            UserGroup group = new UserGroup
            {
                Code = request.GroupCode,
                Description = request.GroupDescription
            };

            UserState state = new UserState
            {
                Description = request.UserStateDescription
            };

            User user = new User
            {
                Login = request.Login,
                Password = request.Password,
                UserGroup = group,
                UserState = state
            };

            await unitOfWork.Users.Create(user);
            await unitOfWork.SaveAsync();

            return user;
        }

        public async ValueTask Delete(int userId)
        {
            await unitOfWork.Users.Delete(userId);
            await unitOfWork.SaveAsync();
        }

        public async ValueTask<User> Get(int userId)
        {
            var user = await unitOfWork.Users.Get(userId);

            if (user == null)
            {
                throw new Exception($"User {userId} not found");
            }

            return user;
        }

        public async ValueTask<PagedListService<User>> GetAll(AllUsersParametersRequest request)
        {
            var users = await unitOfWork.Users.GetAll();

            return PagedListService<User>.ToPagedList(users, request.PageNumber, request.PageSize);
        }

        private async ValueTask<bool> CheckLogin(string login)
        {
            return await unitOfWork.Users.AnyLogin(login);
        }

        private async ValueTask<bool> CheckGroupCode()
        {
            return await unitOfWork.Users.AnyAdmin();
        }
    }
}
