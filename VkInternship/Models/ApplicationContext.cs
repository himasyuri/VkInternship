using Microsoft.EntityFrameworkCore;

namespace VkInternship.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserGroup> UserGroups { get; set; } = null!;

        public DbSet<UserState> UserStates { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Globals.Connection);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGroup>().ToTable("user_groups");
            modelBuilder.Entity<UserState>().ToTable("user_states");
        }
    }
}
