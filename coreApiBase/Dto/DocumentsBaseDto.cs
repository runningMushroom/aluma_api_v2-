﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class DocumentsBaseDto
    {
        public Guid Id { get; set; }
        public string DocuemtnData { get; set; }
        public string B64Prefix { get; set; }
        public string Name { get; set; }
    }
}