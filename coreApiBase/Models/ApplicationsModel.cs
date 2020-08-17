using alumaApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    public class ApplicationsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public ICollection<ApplicationStepModel> Steps { get; set; }
        public bool Signed { get; set; }
    }

    public class ApplicationModelBuilder : IEntityTypeConfiguration<ApplicationsModel>
    {
        public void Configure(EntityTypeBuilder<ApplicationsModel> mb)
        {
            mb.HasMany(c => c.Steps)
                .WithOne(c => c.Application)
                .HasForeignKey(c => c.ApplicationId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}