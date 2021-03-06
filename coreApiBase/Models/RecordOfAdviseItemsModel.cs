﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("record_of_advise_items")]
    public class RecordOfAdviseItemsModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid RecordOfAdviseId { get; set; }
        public RecordOfAdviseModel RecordOfAdvise { get; set; }
        public string ProductName { get; set; }
        public double RecommendedLumpSum { get; set; }
        public double AcceptedLumpSum { get; set; }
        public double RecommendedRecurringPremium { get; set; }
        public double AcceptedRecurringPremium { get; set; }
        public string DeveationReason { get; set; }
    }
}