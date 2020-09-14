using alumaApi.Models.Schedules.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryTrust
{
    [Table("primary_schedule_trust_details")]
    public class TrustDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryTrustModel Schedule { get; set; }
        public string TrustType { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Purpose { get; set; }
        public string Location { get; set; }
        public string InCareAddress { get; set; }
        public string InCareName { get; set; }
        public ICollection<TrustAddressItemsModel> AdressItems { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

    public class TrustDetailsModelBuilder : IEntityTypeConfiguration<TrustDetailsModel>
    {
        public void Configure(EntityTypeBuilder<TrustDetailsModel> mb)
        {
            mb.HasMany(c => c.AdressItems)
                .WithOne(c => c.TrustDetails)
                .HasForeignKey(c => c.TrustDetailsId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

    [Table("primary_schedule_trust_details_address_items")]
    public class TrustAddressItemsModel : BaseAddressModel
    {
        public Guid Id { get; set; }
        public Guid TrustDetailsId { get; set; }
        public TrustDetailsModel TrustDetails { get; set; }
    }
}