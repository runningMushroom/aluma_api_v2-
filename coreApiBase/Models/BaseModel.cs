using System;

namespace vueBuilderApi.Models
{
    // all other models must inherit from this model
    public class BaseModel
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}