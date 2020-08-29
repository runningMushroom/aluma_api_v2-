using alumaApi.Models.Static;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StringHasher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumaApi.Models
{
    [Table("users")]
    public class UserModel : BaseUserModel
    {
        public byte[] Signature { get; set; }
        public byte[] ProfileImage { get; set; }
        public ICollection<ApplicationsModel> Applications { get; set; }
        public BrokerDetailsModel BrokerDetails { get; set; }
    }

    public class UserModelBuilder : IEntityTypeConfiguration<UserModel>
    {
        private IStringHasher _hasher = new StringHasherRepo();

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
            mb.HasOne(c => c.BrokerDetails)
                .WithOne(c => c.User)
                .HasForeignKey<BrokerDetailsModel>(c => c.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
            mb.HasData(new UserModel()
            {
                Id = Guid.NewGuid(),
                Email = "root@aluma.co.za",
                FirstName = "rootUser",
                IdNumber = "9000000000000",
                LastName = "root",
                MobileNumber = "0810000000",
                MobileVerified = true,
                Role = Roles.Admin,
                Password = _hasher.CreateHash("12qwaszx"),
                //BrokerDetails = new BrokerDetailsModel()
                //{
                //    UnitNo = "922",
                //    Complex = "Cheverney",
                //    StreetNo = "30",
                //    StreetName = "Joan",
                //    Suburb = "La Montagne",
                //    City = "Pretoria",
                //    PostalCode = "0184",
                //    Country = "South Africa",
                //    Supervised = false,
                //}
            });
        }
    }
}