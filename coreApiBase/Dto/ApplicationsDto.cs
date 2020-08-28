using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class ApplicationsDto
    {
        public Guid Id { get; set; }
        public UserDto User { get; set; }
        public List<ApplicationStepsDto> Steps { get; set; }
        public ICollection<ApplicationDocumentsDto> Documents { get; set; }
        public bool SigningRightsGiven { get; set; }
        public bool Signed { get; set; }
        public string Description { get; set; }
        public string BdaNumber { get; set; }
        public bool PaymentConfirmed { get; set; }
    }
}