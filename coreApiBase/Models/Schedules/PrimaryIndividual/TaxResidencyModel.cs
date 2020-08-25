using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_tax_residency")]
    public class TaxResidencyModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryIndividualModel Schedule { get; set; }
        public string TaxNumber { get; set; }
        public bool TaxObligations { get; set; }
        public ICollection<TaxResidencyItemsModel> TaxResidencyItems { get; set; }
        public bool UsCitizen { get; set; }
        public bool UsRelinquished { get; set; }
        public bool UsOther { get; set; }
    }

    public class TaxResidencyModelBuilder : IEntityTypeConfiguration<TaxResidencyModel>
    {
        public void Configure(EntityTypeBuilder<TaxResidencyModel> mb)
        {
            mb.HasMany(c => c.TaxResidencyItems)
                .WithOne(c => c.TaxResidency)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}