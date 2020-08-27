using alumaApi.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("required_secondary_schedules")]
    public class RequiredSecondarySchedulesModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
        public ScheduleTypesEnum ScheduleType { get; set; }
        public ICollection<RequiredSecondarySchedulesContactsModel> Contacts { get; set; }
    }

    public class RequiredSecondarySchedulesModelBuilder : IEntityTypeConfiguration<RequiredSecondarySchedulesModel>
    {
        public void Configure(EntityTypeBuilder<RequiredSecondarySchedulesModel> mb)
        {
            mb.HasMany(c => c.Contacts)
                .WithOne(c => c.RequiredSecondarySchedules)
                .HasForeignKey(c => c.RequiredSecondarySchedulesId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}