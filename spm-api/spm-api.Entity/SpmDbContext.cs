using Microsoft.EntityFrameworkCore;

namespace spm_api.Entity
{
    public class SpmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Group> Groups { get; set; }

        public SpmDbContext(DbContextOptions<SpmDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(item => item.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Group>().Property(item => item.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Group>().HasMany(item => item.ChildGroups).WithOne(item => item.ParentGroup).HasForeignKey(item => item.ParentGroupId);
            modelBuilder.Entity<Group>().HasMany(item => item.Users).WithMany(item => item.Groups);
        }
    }
}
