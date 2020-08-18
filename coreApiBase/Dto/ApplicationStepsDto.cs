using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class ApplicationStepsDto
    {
        public Guid Id { get; set; }
        public string StepType { get; set; }
        public Guid DataId { get; set; }
        public int Order { get; set; }
        public bool ActiveStep { get; set; }
        public bool Complete { get; set; }
    }
}