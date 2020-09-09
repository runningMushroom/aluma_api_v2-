using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("broker_details")]
    public class BrokerDetailsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
        public string UnitNo { get; set; }
        public string Complex { get; set; }
        public string StreetNo { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime EmploymentDate { get; set; }
        public bool Supervised { get; set; }
    }

    public class BrokerDetailsModelBuilder : IEntityTypeConfiguration<BrokerDetailsModel>
    {
        public void Configure(EntityTypeBuilder<BrokerDetailsModel> mb)
        {
            mb.HasData(new BrokerDetailsModel()
            {
                Id = Guid.Parse("3F7CB4B6-3B03-4B28-B012-E602EC5A3AAF"),
                UserId = Guid.Parse("3F7CB4B6-3B03-4B28-B012-E602EC5C36AF"),
                UnitNo = "922",
                Complex = "Cheverney",
                StreetNo = "30",
                StreetName = "Joan",
                Suburb = "La Montagne",
                City = "Pretoria",
                PostalCode = "0184",
                Country = "South Africa",
                Supervised = false,
                EmploymentDate = DateTime.Now.AddYears(-1),
            });
        }
    }
}