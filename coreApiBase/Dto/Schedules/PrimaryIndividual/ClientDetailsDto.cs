using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryIndividual
{
    public class ClientDetailsDto
    {
        public Guid ScheduleId { get; set; }
        public string ClientType { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string FirstNames { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string CountryOfBirth { get; set; }
        public string CityOfBirth { get; set; }
        public string Nationality { get; set; }
        public ICollection<IdentityDetailsDto> IdentityDetails { get; set; }
        public string EmploymentStatus { get; set; }
        public string Employer { get; set; }
        public string Industry { get; set; }
        public string Occupation { get; set; }
    }
}