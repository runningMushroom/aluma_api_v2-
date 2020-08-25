using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models.Schedules.PrimaryIndividual
{
    [Table("primary_schedule_individual_client_details")]
    public class ClientDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public PrimaryIndividualModel Schedule { get; set; }
        public string ClientType { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string Nationality { get; set; }
        public ICollection<IdentityDetailsModel> IdentityDetails { get; set; }
        public string EmpoymentStatus { get; set; }
        public string Employer { get; set; }
        public string Industry { get; set; }
        public string Occupation { get; set; }
    }

    public class ClientDetailsModelBuilder : IEntityTypeConfiguration<ClientDetailsModel>
    {
        public void Configure(EntityTypeBuilder<ClientDetailsModel> mb)
        {
            mb.HasMany(c => c.IdentityDetails)
                .WithOne(c => c.ClientDetails)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}