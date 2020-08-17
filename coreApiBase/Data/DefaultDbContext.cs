using Microsoft.EntityFrameworkCore;
using vueBuilderApi.Models;

namespace vueBuilderApi.Data
{
    public class DefaultDbContext : DbContext
    {
        public DefaultDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfiguration(new UserModelBuilder());
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<SystemUserModel> SystemUsers { get; set; }
    }
}