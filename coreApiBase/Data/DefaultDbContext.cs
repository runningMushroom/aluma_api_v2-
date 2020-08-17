using Microsoft.EntityFrameworkCore;
using alumaApi.Models;

namespace alumaApi.Data
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
    }
}