using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("application_documents")]
    public class ApplicationDocumentsModel : DocumentsBaseModel
    {
        public Guid ApplicationId { get; set; }
        public ApplicationsModel Application { get; set; }
    }
}