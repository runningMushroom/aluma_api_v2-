﻿using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using alumaApi.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace alumaApi.Models
{
    [Table("application_steps")]
    public class ApplicationStepModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid ApplicationId { get; set; }
        public ApplicationsModel Application { get; set; }
        public ApplicationStepTypesEnum StepType { get; set; }
        public Guid DataId { get; set; }
        public string ScheduleType { get; set; }
        public int FactoryId { get; set; }
        public string FactoryStep { get; set; }
        public int Order { get; set; }
        public bool ActiveStep { get; set; }
        public bool Complete { get; set; }

        public ApplicationStepModel()
        {
            ActiveStep = false;
            Complete = false;
        }
    }
}