using alumaApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class ApplicationDocumentsDto : DocumentsBaseDto
    {
        public Guid ApplicationId { get; set; }
    }
}