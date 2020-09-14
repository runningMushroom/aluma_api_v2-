using alumaApi.Models.Schedules.PrimaryTrust;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules
{
    [Table("primary_schedule_trust")]
    public class PrimaryTrustModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }

        //public TrustBankDetailsModel BankDetails { get; set; }
        public TrustDetailsModel Details { get; set; }

        public TrustEntityModel Entity { get; set; }
        public TrustTaxResidencyModel TaxResidency { get; set; }
    }

    public class PrimaryTrustModelBuilder : IEntityTypeConfiguration<PrimaryTrustModel>
    {
        public void Configure(EntityTypeBuilder<PrimaryTrustModel> mb)
        {
            //mb.HasOne(c => c.BankDetails)
            //    .WithOne(c => c.Schedule)
            //    .HasForeignKey<TrustBankDetailsModel>(c => c.ScheduleId)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);
            mb.HasOne(c => c.Details)
                .WithOne(c => c.Schedule)
                .HasForeignKey<TrustDetailsModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            mb.HasOne(c => c.Entity)
                .WithOne(c => c.Schedule)
                .HasForeignKey<TrustEntityModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            mb.HasOne(c => c.TaxResidency)
                .WithOne(c => c.Schedule)
                .HasForeignKey<TrustTaxResidencyModel>(c => c.ScheduleId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}