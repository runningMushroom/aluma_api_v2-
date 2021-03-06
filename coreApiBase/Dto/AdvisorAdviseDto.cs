﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class AdvisorAdviseDto
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public Guid StepId { get; set; }
        public Guid UserId { get; set; }
        public string Introduction { get; set; }
        public string Notes { get; set; }
        public string MaterialInformation { get; set; }
        public ICollection<AdvisorAdvisedProductsDto> AdvisedProducts { get; set; }
    }
}