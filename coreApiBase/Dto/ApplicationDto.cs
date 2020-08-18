using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class ApplicationDto
    {
        public Guid Id { get; set; }

        public bool Signed { get; set; }

        public string Description { get; set; }

        public List<ApplicationStepsDto> Steps { get; set; }
    }
}