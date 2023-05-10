using VkInternship.Models;

namespace VkInternship.Repositories
{
    public class UnitOfWork : IDisposable
    {
        private ApplicationContext db = new ApplicationContext();
        private UserRepository userRepository;

        public UserRepository Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }

                return userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool diposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.diposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.diposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
