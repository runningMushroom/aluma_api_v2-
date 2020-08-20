using Microsoft.EntityFrameworkCore;
using alumaApi.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

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
            mb.ApplyConfiguration(new ApplicationModelBuilder());
            mb.ApplyConfiguration(new AdvisorAdviseModelBuilder());
        }

        public DbSet<AdvisorAdvisedProductsModel> AdvisorAdvisedProducts { get; set; }
        public DbSet<AdvisorAdviseModel> AdvisorAdvise { get; set; }
        public DbSet<ApplicationsModel> Applications { get; set; }
        public DbSet<ApplicationStepModel> ApplicationSteps { get; set; }
        public DbSet<OtpModel> Otp { get; set; }
        public DbSet<UserModel> Users { get; set; }
    }
}