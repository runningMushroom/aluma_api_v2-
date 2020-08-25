using alumaApi.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    public class DocumentsBaseModel : BaseModel
    {
        public Guid Id { get; set; }
        public byte[] DocuemtnData { get; set; }
        public string B64Prefix { get; set; }
        public string Name { get; set; }
        public DocumentTypesEnum DocumentType { get; set; }
    }
}