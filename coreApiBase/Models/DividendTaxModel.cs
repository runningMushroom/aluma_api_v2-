﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Models
{
    [Table("dividend_tax")]
    public class DividendTaxModel : BaseModel
    {
        public Guid Id { get; set; }
        public Guid StepId { get; set; }
        public Guid ApplicationId { get; set; }
        public string NameSurname { get; set; }
        public string TradingName { get; set; }
        public string AccountReference { get; set; }
        public string NatureOfEntity { get; set; }
        public string IdNo { get; set; }
        public string DateOfBirth { get; set; }
        public string TaxNo { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string Title { get; set; }
        public string Surname { get; set; }
        public string Initials { get; set; }
        public string FirstName { get; set; }
        public string IdNoPassport { get; set; }
        public string Work { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Exemption_1 { get; set; }
        public string Exemption_2 { get; set; }
        public string Exemption_3 { get; set; }
        public string Exemption_4 { get; set; }
        public string Exemption_5 { get; set; }
        public string Exemption_6 { get; set; }
        public string Exemption_7 { get; set; }
        public string Exemption_8 { get; set; }
    }
}