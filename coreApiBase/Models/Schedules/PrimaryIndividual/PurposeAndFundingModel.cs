using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_purpose_and_funding")]
    public class PurposeAndFundingModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryIndividualModel Schedule { get; set; }
        public ICollection<PurposeOptionModel> PurposeOptions { get; set; }
        public string NumberOfDeposits { get; set; }
        public string NumberOfWithdrrawals { get; set; }
        public string DepositsValue { get; set; }
        public string WithdrawalsValue { get; set; }
        public string SourceOfFunds { get; set; }
        public string SourceOfWealth { get; set; }
    }

    public class PurposeAndFundingModelBuilder : IEntityTypeConfiguration<PurposeAndFundingModel>
    {
        public void Configure(EntityTypeBuilder<PurposeAndFundingModel> mb)
        {
            mb.HasMany(c => c.PurposeOptions)
                .WithOne(c => c.PurposeAndFunding)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}