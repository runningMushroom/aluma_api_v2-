using alumaApi.Models.Schedules.PrimaryIndividual;
using alumaApi.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules
{
    [Table("primary_schedule_individual")]
    public class PrimaryIndividualModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
        public BankDetailsModel BankDetails { get; set; }
        public ClientDetailsModel ClientDetails { get; set; }
        public ContactDetailsModel ContactDetails { get; set; }
        public DeclerationsModel Declerations { get; set; }
        public PurposeAndFundingModel PurposeAndFunding { get; set; }
        public TaxResidencyModel TaxResidency { get; set; }
    }

    public class PrimaryIndividualModelBuilder : IEntityTypeConfiguration<PrimaryIndividualModel>
    {
        public void Configure(EntityTypeBuilder<PrimaryIndividualModel> mb)
        {
            mb.HasOne(c => c.BankDetails)
                .WithOne(c => c.Schedule)
                .HasForeignKey<BankDetailsModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            mb.HasOne(c => c.ClientDetails)
                .WithOne(c => c.Schedule)
                .HasForeignKey<ClientDetailsModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            mb.HasOne(c => c.ContactDetails)
                .WithOne(c => c.Schedule)
                .HasForeignKey<ContactDetailsModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            mb.HasOne(c => c.Declerations)
                .WithOne(c => c.Schedule)
                .HasForeignKey<DeclerationsModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            mb.HasOne(c => c.PurposeAndFunding)
                .WithOne(c => c.Schedule)
                .HasForeignKey<PurposeAndFundingModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            mb.HasOne(c => c.TaxResidency)
                .WithOne(c => c.Schedule)
                .HasForeignKey<TaxResidencyModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}