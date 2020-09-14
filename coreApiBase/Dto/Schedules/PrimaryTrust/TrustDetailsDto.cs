using alumaApi.Dto.Schedules.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto.Schedules.PrimaryTrust
{
    public class TrustDetailsDto
    {
        public Guid Id { get; set; }
        public Guid ScheduleId { get; set; }
        public string TrustType { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Purpose { get; set; }
        public string Location { get; set; }
        public string InCareAddress { get; set; }
        public string InCareName { get; set; }
        public ICollection<TrustAddressItemsDto> AdressItems { get; set; }
        public string ContactPerson { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }

    public class TrustAddressItemsDto : BaseAddressDto
    {
        public Guid Id { get; set; }
        public Guid TrustDetailsId { get; set; }
    }
}