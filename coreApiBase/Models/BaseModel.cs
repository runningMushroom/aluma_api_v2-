using System;

namespace alumaApi.Models
{
    // all other models must inherit from this model
    public class BaseModel
    {
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public BaseModel()
        {
            Created = DateTime.Now;
            Modified = DateTime.Now;
        }
    }
}