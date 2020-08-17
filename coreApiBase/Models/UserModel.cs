using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumaApi.Models
{
    [Table("users")]
    public class UserModel : BaseUserModel
    {
        public ICollection<ApplicationsModel> Applications { get; set; }
    }

    public class UserModelBuilder : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> mb)
        {
            mb.HasIndex(c => c.IdNumber).IsUnique();
            mb.HasIndex(c => c.Email).IsUnique();
            mb.HasIndex(c => c.MobileNumber).IsUnique();
            mb.HasMany(c => c.Applications)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}