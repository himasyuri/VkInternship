using Microsoft.EntityFrameworkCore;
using VkInternship.Models;

namespace VkInternship.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext context;

        public UserRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public async Task<bool> AnyAdmin()
        {
            return await context.Users.Include(p => p.UserGroup)
                                .AnyAsync(p => p.UserGroup.Code == "Admin");
        }

        public async Task<bool> AnyLogin(string login)
        {
            return await context.Users.AnyAsync(u => u.Login == login);
        }

        public async Task Create(User user)
        {
            await context.Users.AddAsync(user);
        }

        public async Task Delete(int id)
        {
            var user = await context.Users.Include(p => p.UserState)
                                          .FirstAsync(p => p.Id == id);
            if (user.UserState == null)
            {
                throw new Exception($"Not found user with id {id}");
            }

            user.UserState.Code = "Blocked";
        }

        public async Task<User> Get(int id)
        {
            var user = await context.Users.Include(p => p.UserGroup)
                                          .Include(p => p.UserState)
                                          .FirstAsync(p => p.Id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await context.Users.Include(p => p.UserGroup)
                                      .Include(p => p.UserState)
                                      .ToListAsync();
        }
    }
}
