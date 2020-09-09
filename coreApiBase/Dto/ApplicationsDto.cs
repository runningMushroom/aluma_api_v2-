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
        public bool PrimaryFormsComplete { get; set; }
        public bool SecondaryFormsComplete { get; set; }
        public bool BankValidationComplete { get; set; }
        public bool DocumentsCreated { get; set; }
        public bool AllowSignature { get; set; }
        public bool DocumentsSigned { get; set; }
        public string BdaNumber { get; set; }
        public string Description { get; set; }
        public bool PaymentConfirmed { get; set; }
    }
}