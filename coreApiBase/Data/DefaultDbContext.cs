using Microsoft.EntityFrameworkCore;
using alumaApi.Models;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using alumaApi.Models.Schedules;
using alumaApi.Models.Schedules.PrimaryIndividual;

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

            // Primary Individual
            mb.ApplyConfiguration(new PrimaryIndividualModelBuilder());
            mb.ApplyConfiguration(new ClientDetailsModelBuilder());
            mb.ApplyConfiguration(new PurposeAndFundingModelBuilder());
            mb.ApplyConfiguration(new TaxResidencyModelBuilder());
        }

        public DbSet<AdvisorAdvisedProductsModel> AdvisorAdvisedProducts { get; set; }
        public DbSet<AdvisorAdviseModel> AdvisorAdvise { get; set; }
        public DbSet<ApplicationDocumentsModel> ApplicationDocuments { get; set; }
        public DbSet<ApplicationsModel> Applications { get; set; }
        public DbSet<ApplicationStepModel> ApplicationSteps { get; set; }
        public DbSet<BankVerificationsModel> BankVerifications { get; set; }
        public DbSet<RiskProfileModel> RiskProfiles { get; set; }
        public DbSet<OtpModel> Otp { get; set; }
        public DbSet<UserModel> Users { get; set; }

        // Primary Individual Schedule
        public DbSet<PrimaryIndividualModel> PrimaryIndividuals { get; set; }

        public DbSet<BankDetailsModel> PI_BankDetails { get; set; }
        public DbSet<ContactDetailsModel> PI_ContactDetails { get; set; }
        public DbSet<DeclerationsModel> PI_Declerations { get; set; }
        public DbSet<IdentityDetailsModel> PI_IdentityDetails { get; set; }
        public DbSet<PurposeAndFundingModel> PI_PurposeAndFundings { get; set; }
        public DbSet<PurposeOptionModel> PI_PurposeOptions { get; set; }
        public DbSet<TaxResidencyItemsModel> PI_TaxResidencyItems { get; set; }
        public DbSet<TaxResidencyModel> PI_TaxResidencies { get; set; }
    }
}