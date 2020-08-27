using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Dto
{
    public class DividendTaxDto
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
        public string TitleSurname { get; set; }
        public string InitialsFirstName { get; set; }
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