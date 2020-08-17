using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace vueBuilderApi.Models
{
    [Table("users")]
    public class UserModel : BaseUserModel
    {
    }

    public class UserModelBuilder : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> mb)
        {
            mb.HasIndex(c => c.IdNumber).IsUnique();
            mb.HasIndex(c => c.Email).IsUnique();
            mb.HasIndex(c => c.MobileNumber).IsUnique();
        }
    }
}