using alumaApi.Data;
using alumaApi.Dto;
using alumaApi.Enum;
using alumaApi.Models;
using alumaApi.Models.Schedules;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using MailKit;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using Signiflow;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace alumaApi.Repositories
{
    public interface IApplicationRepo : IRepoBase<ApplicationsModel>
    {
        ApplicationDocumentsModel PopulateTestDocument();

        void CreateDocuments(Guid applicationId);

        void SignDocuments(Guid applicationId);

        void ProcessApplication(Guid applicationId);
    }

    public class ApplicationRepo : RepoBase<ApplicationsModel>, IApplicationRepo
    {
        private readonly DefaultDbContext _context;
        private readonly IWebHostEnvironment _host;
        private readonly ISigniflowRepo _signiflow;

        public ApplicationRepo(DefaultDbContext databaseContext, IWebHostEnvironment host,
            ISigniflowRepo signiflow) : base(databaseContext)
        {
            _context = databaseContext;
            _host = host;
            _signiflow = signiflow;
        }

        public void ProcessApplication(Guid applicationId)
        {
            var application = _context.Applications.Find(applicationId);

            if (!application.PrimaryFormsComplete)
                throw new Exception("PrimaryFormsComplete_False");

            if (!application.BankValidationComplete)
                throw new Exception("BankValidationComplete_False");

            if (!application.DocumentsCreated)
                CreateDocuments(applicationId);

            if (!application.DocumentsSigned && !application.AllowSignature)
                throw new Exception("AllowSignature_False");

            if (!application.DocumentsSigned && application.AllowSignature)
                SignDocuments(applicationId);
        }

        public void SignDocuments(Guid applicationId)
        {
            var application = _context.Applications
                .Where(c => c.Id == applicationId)
                .Include(c => c.Documents)
                .Include(c => c.User)
                .Include(c => c.Steps)
                .First();

            var advisorId = _context.AdvisorAdvise
                .Where(c => c.ApplicationId == applicationId)
                .First()
                .AdvisorId;

            var advisor = _context.Users
                .Where(c => c.Id == advisorId)
                .Include(c => c.BrokerDetails)
                .First();

            application.Documents.ToList().ForEach(doc =>
            {
                List<SignerListItemDto> signers = null;

                signers =
                    // Intro Letter
                    doc.DocumentType == DocumentTypesEnum.IntorLetter ?
                        new List<SignerListItemDto>()
                        {   // client
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                XField = 40,
                                YField = 690,
                                HField = 90,
                                WField = 120,
                                Page = 2
                            })
                        } :

                    // FNA
                    doc.DocumentType == DocumentTypesEnum.FinancialNeedsAnalysis ?
                        new List<SignerListItemDto>()
                        {   // client
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                XField = 350,
                                YField = 575,
                                HField = 90,
                                WField = 120,
                                Page = 1,
                            }),
                            // advisor
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(advisor.Signature),
                                FirstName = advisor.FirstName,
                                LastName = advisor.LastName,
                                Email = advisor.Email,
                                IdNo = advisor.IdNumber,
                                Mobile = advisor.MobileNumber,
                                XField = 440,
                                YField = 635,
                                HField = 90,
                                WField = 120,
                                Page = 1,
                            })
                        } :

                    // Primary Schedule Individual
                    doc.DocumentType == DocumentTypesEnum.PrimarySchedule &&
                        application.Steps.First(c => c.StepType == ApplicationStepTypesEnum.PrimarySchedule).ScheduleType == "Individual" ?
                        new List<SignerListItemDto>()
                        {   // client
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                XField = 180,
                                YField = 110,
                                Page = 5
                            })
                        } :

                    // Risk Profile
                    doc.DocumentType == DocumentTypesEnum.RiskProfile ?
                        new List<SignerListItemDto>()
                        {   // client
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                XField = 160,
                                YField = 320,
                                HField = 90,
                                WField = 120,
                                Page = 2
                            })
                        } :

                    // Record of advise
                    doc.DocumentType == DocumentTypesEnum.RiskProfile ?
                        new List<SignerListItemDto>()
                        {   // client
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                XField = 120,
                                YField = 590,
                                Page = 4
                            }),
                            // advisor
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(advisor.Signature),
                                FirstName = advisor.FirstName,
                                LastName = advisor.LastName,
                                Email = advisor.Email,
                                IdNo = advisor.IdNumber,
                                Mobile = advisor.MobileNumber,
                                XField = 380,
                                YField = 580,
                                Page = 4
                            })
                        } :

                    // fsp mandate
                    doc.DocumentType == DocumentTypesEnum.FspMandate ?
                        FspMandateSigningList(application, advisor) :

                    // Dividend tax
                    doc.DocumentType == DocumentTypesEnum.RiskProfile ?
                        new List<SignerListItemDto>()
                        {   // client initial
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                IncludeSignedBy = false,
                                XField = 470,
                                YField = 725,
                                HField = 60,
                                WField = 80,
                                Page = 1
                            }),
                            // client signature
                            _signiflow.CreateSignerListItem(new SignerDto() {
                                Signature = Convert.ToBase64String(application.User.Signature),
                                FirstName = application.User.FirstName,
                                LastName = application.User.LastName,
                                Email = application.User.Email,
                                IdNo = application.User.IdNumber,
                                Mobile = application.User.MobileNumber,
                                XField = 400,
                                YField = 145,
                                Page = 2
                            })
                        } :
                    null;

                var ceremony = _signiflow.CreateMultipleSignersCeremony(doc.DocuemtnData,
                    doc.Name, signers);

                doc.DocuemtnData = Convert.FromBase64String(
                    _signiflow.RunMultiSignerCeremony(ceremony));

                _context.ApplicationDocuments.Update(doc);
            });

            application.DocumentsSigned = true;
            _context.Applications.Update(application);
            _context.SaveChanges();
        }

        private List<SignerListItemDto> FspMandateSigningList(ApplicationsModel application, UserModel advisor)
        {
            var signerList = new List<SignerListItemDto>();

            var mandate = _context.FspMandatates
                .Where(c => c.ApplicationId == application.Id)
                .First();

            var pageList = mandate.Objective[0].ToString() == "L" ?
                new List<int> { 2, 3, 4, 5, 6, 7, 8 } : // Limited Discretiuon
                new List<int> { 2, 3, 4, 5, 6, 7, 9 }; // Full Discretion

            pageList.ForEach(p => signerList.Add(_signiflow.CreateSignerListItem(new SignerDto()
            {
                Signature = Convert.ToBase64String(application.User.Signature),
                FirstName = application.User.FirstName,
                LastName = application.User.LastName,
                Email = application.User.Email,
                IdNo = application.User.IdNumber,
                Mobile = application.User.MobileNumber,
                IncludeSignedBy = false,
                XField = 480,
                YField = 775,
                HField = 60,
                WField = 80,
                Page = p
            })));

            signerList.Add(_signiflow.CreateSignerListItem(new SignerDto()
            {   // client
                Signature = Convert.ToBase64String(application.User.Signature),
                FirstName = application.User.FirstName,
                LastName = application.User.LastName,
                Email = application.User.Email,
                IdNo = application.User.IdNumber,
                Mobile = application.User.MobileNumber,
                XField = 160,
                YField = 590,
                Page = 7
            }));

            signerList.Add(_signiflow.CreateSignerListItem(new SignerDto()
            {   // client
                Signature = Convert.ToBase64String(application.User.Signature),
                FirstName = application.User.FirstName,
                LastName = application.User.LastName,
                Email = application.User.Email,
                IdNo = application.User.IdNumber,
                Mobile = application.User.MobileNumber,
                XField = mandate.Objective[0].ToString() == "L" ? 120 : 160,
                YField = mandate.Objective[0].ToString() == "L" ? 680 : 520,
                Page = mandate.Objective[0].ToString() == "L" ? 9 : 8
            }));

            signerList.Add(_signiflow.CreateSignerListItem(new SignerDto()
            {   // Advisor
                Signature = Convert.ToBase64String(advisor.Signature),
                FirstName = advisor.FirstName,
                LastName = advisor.LastName,
                Email = advisor.Email,
                IdNo = advisor.IdNumber,
                Mobile = advisor.MobileNumber,
                XField = 160,
                YField = 470,
                Page = 7
            }));

            return signerList;
        }

        public void CreateDocuments(Guid applicationId)
        {
            var appl = _context.Applications
                .Include(c => c.Steps)
                .Include(c => c.Documents)
                .Include(c => c.User)
                .First(c => c.Id == applicationId);

            // get the advisor advise
            var advise = _context.AdvisorAdvise.First(c => c.ApplicationId == applicationId);

            // get the advisor
            var advisor = _context.Users
                .Include(c => c.BrokerDetails)
                .First(c => c.Id == advise.AdvisorId);

            // If we did a digital KYC, get it
            var kycExist = _context.KycMetaData.Any(c => c.ApplicationId == applicationId);
            KycMetaDataModel kyc = null;
            if (kycExist)
            {
                kyc = _context.KycMetaData.First(c => c.ApplicationId == applicationId);
            }

            // get record of advise
            var roa = _context.RecordOfAdvise
                .Include(c => c.SelectedProducts)
                .First(c => c.ApplicationId == applicationId);

            // get the bank validation data
            var bankValidation = _context.BankVerifications
                .First(c => c.ApplicationId == applicationId);

            // get schedule step
            var scheduleStep = _context.ApplicationSteps
                .First(c => c.ApplicationId == applicationId &&
                    c.StepType == ApplicationStepTypesEnum.PrimarySchedule);

            // get scheduele details
            AddressDto address = null;
            ClientDto client = null;
            if (scheduleStep.ScheduleType == "Individual")
            {
                var schedule = _context.PrimaryIndividuals
                    .Where(c => c.ApplicationId == applicationId)
                    .Include(c => c.ContactDetails)
                    .Include(c => c.ClientDetails)
                    .Include(c => c.TaxResidency)
                    .First();

                address = new AddressDto()
                {
                    UnitNumber = schedule.ContactDetails.UnitNumber,
                    Complex = schedule.ContactDetails.Complex,
                    StreetNumber = schedule.ContactDetails.StreetNumber,
                    StreetName = schedule.ContactDetails.StreetName,
                    City = schedule.ContactDetails.City,
                    Country = schedule.ContactDetails.Country,
                    Suburb = schedule.ContactDetails.Suburb,
                    PostalCode = schedule.ContactDetails.PostalCode,
                };
                client = new ClientDto()
                {
                    DateOfBirth = schedule.ClientDetails.DateOfBirth,
                    TaxNumber = schedule.TaxResidency.TaxNumber
                };
            }

            var risk = _context.RiskProfiles.First(c => c.ApplicationId == applicationId);

            var fdpMandate = _context.FspMandatates.First(c => c.ApplicationId == applicationId);

            var divTax = _context.Dividends.First(c => c.ApplicationId == applicationId);

            var documentList = new List<ApplicationDocumentsModel>();

            // intro letter
            documentList.Add(kycExist == true ?
                CreateIntroLetter(appl.User, kyc.FirstNames, kyc.SurName, kyc.IdNumber) :
                CreateIntroLetter(appl.User, appl.User.FirstName, appl.User.LastName, appl.User.IdNumber));

            // FNA
            documentList.Add(kycExist == true ?
                CreateFinancialNeedsAnalysis(roa, address.City, kyc.FirstNames, kyc.SurName, kyc.IdNumber, advisor) :
                CreateFinancialNeedsAnalysis(roa, address.City, appl.User.FirstName, appl.User.LastName, appl.User.IdNumber, advisor));

            // Bank Validation
            documentList.Add(kycExist == true ?
                CreateBankValidationReport(bankValidation, kyc.FirstNames, kyc.SurName) :
                CreateBankValidationReport(bankValidation, appl.User.FirstName, appl.User.LastName));

            // Primary Schedule
            ApplicationDocumentsModel schedulePrimary = null;
            if (scheduleStep.ScheduleType == "Individual")
            {
                var schedule = _context.PrimaryIndividuals
                .Where(c => c.ApplicationId == applicationId)
                .Include(c => c.ContactDetails)
                .Include(c => c.ClientDetails)
                .Include(c => c.TaxResidency)
                .First();

                schedulePrimary = CreatePrimaryIndividualSchedule(schedule, bankValidation);
            };

            // Risk Profile
            documentList.Add(kycExist == true ?
                CreateRiskProfile(risk, advisor, advise, kyc.FirstNames, kyc.SurName, kyc.IdNumber) :
                CreateRiskProfile(risk, advisor, advise, appl.User.FirstName, appl.User.LastName, appl.User.IdNumber));

            // Record Of Advise
            documentList.Add(kycExist == true ?
                CreateRecordOfAdvie(roa, kyc.FirstNames, kyc.SurName, kyc.IdNumber, advisor, risk, advise) :
                CreateRecordOfAdvie(roa, appl.User.FirstName, appl.User.LastName, appl.User.IdNumber, advisor, risk, advise));

            // FSP Mandate
            documentList.Add(kycExist == true ?
                CreateFspMandate(kyc.FirstNames, kyc.SurName, risk, fdpMandate, address, appl.User, advisor, roa, bankValidation) :
                CreateFspMandate(appl.User.FirstName, appl.User.LastName, risk, fdpMandate, address, appl.User, advisor, roa, bankValidation));

            // Dividend
            documentList.Add(kycExist == true ?
                CreateDividendTax(divTax, address, client, kyc.FirstNames, kyc.SurName, kyc.IdNumber) :
                CreateDividendTax(divTax, address, client, appl.User.FirstName, appl.User.LastName, appl.User.IdNumber));

            documentList.ForEach(doc =>
            {
                doc.ApplicationId = appl.Id;
                doc.Name =
                    doc.DocumentType == DocumentTypesEnum.IntorLetter ?
                        $"Intro Letter: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.FinancialNeedsAnalysis ?
                        $"Financial Needs Analysis: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.BankVerification ?
                        $"Bank Validation Report: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.PrimarySchedule ?
                        $"Primary Schedule, Individual: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.RiskProfile ?
                        $"Risk Profile: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.RecordOfAdvise ?
                        $"Record of Advise: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.FspMandate ?
                        $"FSP Mandate: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    doc.DocumentType == DocumentTypesEnum.Dividende ?
                        $"Dividend Tax: {appl.User.FirstName} {appl.User.LastName}.pdf" :
                    null;

                if (appl.Documents.Any(c => c.DocumentType == doc.DocumentType))
                    _context.ApplicationDocuments.Update(doc);
                else
                    _context.ApplicationDocuments.Add(doc);

                _context.SaveChanges();
            });

            // update applicaiton - documents created
            appl.DocumentsCreated = true;
            _context.Applications.Update(appl);
            _context.SaveChanges();
        }

        //private ApplicationDocumentsModel P()
        //{
        //    var data = new Dictionary<string, string>();

        //    return new ApplicationDocumentsModel() { DocuemtnData = PopulateDocument("IntroLetter.pdf", data) };
        //}

        private ApplicationDocumentsModel CreateDividendTax(DividendTaxModel dividend, AddressDto address,
            ClientDto client, string firstName, string lastName, string idNumber)
        {
            var d = new Dictionary<string, string>();
            d["NameSurname"] = $"{firstName} {lastName}";
            d[dividend.NatureOfEntity] = "X";
            d["IdNo"] = idNumber;
            d["DateOfBirth"] = client.DateOfBirth;
            d["TaxNo"] = client.TaxNumber;
            d["Address"] = $"{address.UnitNumber} {address.Complex} " +
                $"{address.StreetNumber} {address.StreetName} " +
                $"{address.Suburb} {address.City} {address.City}";
            d["Postal"] = address.PostalCode;
            d["Country"] = address.Country;
            d["TitleSurname"] = $"{dividend.Title} {dividend.Surname}";
            d["InitialsFirstName"] = $"{dividend.FirstName} {dividend.Initials}";
            d["IdNoPassport"] = dividend.IdNoPassport;
            d["Work"] = dividend.Work;
            d["Home"] = dividend.Home;
            d["Mobile"] = dividend.Mobile;
            d["Email"] = dividend.Email;
            d["sigName1"] = $"{firstName} {lastName}";
            d["sigDate1"] = DateTime.Now.ToShortDateString();
            d["sigCap1"] = "Self";
            d["Exemption_1"] = dividend.Exemption_1 ?? string.Empty;
            d["Exemption_2"] = dividend.Exemption_2 ?? string.Empty;
            d["Exemption_3"] = dividend.Exemption_3 ?? string.Empty;
            d["Exemption_4"] = dividend.Exemption_4 ?? string.Empty;
            d["Exemption_5"] = dividend.Exemption_5 ?? string.Empty;
            d["Exemption_6"] = dividend.Exemption_6 ?? string.Empty;
            d["Exemption_7"] = dividend.Exemption_7 ?? string.Empty;
            d["Exemption_8"] = dividend.Exemption_8 ?? string.Empty;

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("Dividend.pdf", d),
                DocumentType = DocumentTypesEnum.Dividende
            };
        }

        private ApplicationDocumentsModel CreateFspMandate(string firstname, string lastname,
            RiskProfileModel risk, FspMandateModel man, AddressDto address,
            UserModel client, UserModel adviser, RecordOfAdviseModel roa, BankVerificationsModel bv)
        {
            var d = new Dictionary<string, string>();
            var clientDetails = $"{firstname} {lastname}";
            var Advisor = $"{adviser.FirstName} {adviser.LastName}";

            d["ClientDetails_a"] = clientDetails;

            var p2 = string.Empty;
            foreach (var p in roa.SelectedProducts)
                p2 += p.ProductName;
            d["Products"] = p2;

            d["Bank"] = bv.BankName;
            d["Branch"] = bv.BranchCode;
            d["AccNo"] = bv.AccountNumber;

            d["StartDate"] = DateTime.Now.ToShortDateString();

            d["Address_1"] = $"{address.UnitNumber} {address.Complex}";
            d["Address_2"] = $"{address.StreetNumber} {address.StreetName}," +
                $"{address.Suburb} {address.PostalCode}";
            d["Address_3"] = $"{address.City} {address.Country}";
            d["Email"] = client.Email;
            d["FspSignatory"] = Advisor;
            d["ClientDetails_b"] = clientDetails;

            // location
            d["dateFsp"] = DateTime.Now.ToShortDateString();
            d["dateClient"] = DateTime.Now.ToShortDateString();
            d["atFsp"] = adviser.BrokerDetails.City;
            d["atClient"] = address.City;

            // full / limited discretion
            d[man.Objective] = "x";
            d[$"{man.Objective[0]}{roa.DerivedProfile}"] = "x";
            d["instruction_personal"] = man.InstructionPersonal ?? string.Empty;
            d["instruction_advisor"] = man.InstructionAdvisor ?? string.Empty;
            d["Adviser"] = man.Advisor ?? string.Empty;
            d["instruction_fsp"] = man.InstructionFsp ?? string.Empty;
            d[man.PayoutOption] = "x";

            // client details d
            d[$"{man.Objective[0]}ClientDetails"] = clientDetails;
            d[$"{man.Objective[0]}At"] = address.City;
            d[$"{man.Objective[0]}Date"] = DateTime.Now.ToShortDateString();

            var na = man.Objective[0].ToString() == "L" ? "LNA" : "FNA";
            d[na] = "N/A";

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("FspMandate.pdf", d),
                DocumentType = DocumentTypesEnum.FspMandate
            };
        }

        private ApplicationDocumentsModel CreateRecordOfAdvie(RecordOfAdviseModel roa, string firstname,
            string lastname, string idnumber, UserModel advisor, RiskProfileModel risk,
            AdvisorAdviseModel advise)
        {
            var data = new Dictionary<string, string>();
            var date = DateTime.Today.ToShortDateString();
            var nameSurname = $"{firstname} {lastname}";

            data["BdaNumber"] = string.Empty;
            data["Date_A"] = date;
            data["NameSurname_A"] = nameSurname;
            data["IdNo"] = idnumber;
            data["AdvisorName"] = $"{advisor.FirstName} {advisor.LastName}";
            data["AdvisorEmail"] = advisor.Email;
            data["AdvisorMobile"] = advisor.MobileNumber;
            var advDetails = advisor.BrokerDetails;
            data["AdviserAddress"] = $"{advDetails.UnitNo} {advDetails.Complex} " +
                $"{advDetails.StreetNo} {advDetails.StreetName} {advDetails.Suburb} " +
                $"{advDetails.City}, {advDetails.PostalCode}";
            data["Introduction"] = roa.Introduction;

            var prodProperties = new List<string>() {
                "ProductName", "RecommendedLumpSum", "AcceptedLumpSum",
                "RecommendedRecurringPremium", "AcceptedRecurringPremium" , "DeveationReason"
            };
            foreach (var product in roa.SelectedProducts)
            {
                data[$"{product.ProductName}_ProductName"] = product.ProductName;

                data[$"{product.ProductName}_RecommendedLumpSum"] = product.RecommendedLumpSum > 0 ?
                    product.RecommendedLumpSum.ToString() : string.Empty;

                data[$"{product.ProductName}_AcceptedLumpSum"] = product.AcceptedLumpSum > 0 ?
                    product.AcceptedLumpSum.ToString() : string.Empty;

                data[$"{product.ProductName}_RecommendedRecurringPremium"] = product.RecommendedRecurringPremium > 0 ?
                    product.RecommendedRecurringPremium.ToString() : string.Empty; ;

                data[$"{product.ProductName}_AcceptedRecurringPremium"] = product.AcceptedRecurringPremium > 0 ?
                    product.AcceptedRecurringPremium.ToString() : string.Empty; ;

                data[$"{product.ProductName}_DeveationReason"] = product.DeveationReason ?? string.Empty; ;
            }

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("ROA.pdf.pdf", data),
                DocumentType = DocumentTypesEnum.RecordOfAdvise
            };
        }

        private ApplicationDocumentsModel CreateRiskProfile(RiskProfileModel r, UserModel adviser,
            AdvisorAdviseModel advise, string firstName, string lastName, string idNumber)
        {
            Dictionary<string, string> d = new Dictionary<string, string>();

            d["User"] = $"{firstName} {lastName}";
            d["IdNo"] = idNumber;
            d["Advisor"] = $"{adviser.FirstName ?? string.Empty} {adviser.LastName ?? string.Empty}";
            d["Created"] = DateTime.Today.ToShortDateString();
            d["Goal"] = r.Goal;

            d[r.DerivedProfile] = "X";

            d["DerivedProfile"] = r.DerivedProfile;

            var agreeStr = r.AgreeWithOutcome == true ? "agree_True" : "agree_False";
            if (!r.AgreeWithOutcome)
                d["Reason"] = r.Reason ?? string.Empty;
            d["Date"] = DateTime.Today.ToShortDateString();

            d[r.InvestmentTerm] = "x";
            d[r.RequiredRisk] = "x";
            d[r.RiskTolerance] = "x";
            d[r.RiskCapacity] = "x";

            // advisor notes
            d["advisorNotes"] = advise.Notes;

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("RiskProfile.pdf", d),
                DocumentType = DocumentTypesEnum.RiskProfile
            };
        }

        private ApplicationDocumentsModel CreatePrimaryIndividualSchedule(PrimaryIndividualModel schedule, BankVerificationsModel bv)
        {
            var data = new Dictionary<string, string>();
            var clientDetails = schedule.ClientDetails;
            var contactDetails = schedule.ContactDetails;
            var funding = schedule.PurposeAndFunding;
            var taxResidency = schedule.TaxResidency;

            // client details
            data[clientDetails.ClientType] = clientDetails.ClientType ?? string.Empty;
            data["title"] = clientDetails.Title ?? string.Empty;
            data["dateOfBirth"] = clientDetails.DateOfBirth ?? string.Empty;
            data["initials"] = clientDetails.Initials ?? string.Empty;
            data["surname"] = clientDetails.Surname ?? string.Empty;

            data["countryOfBirth"] = clientDetails.CountryOfBirth ?? string.Empty;
            data["nationality"] = clientDetails.Nationality ?? string.Empty;
            data[clientDetails.EmpoymentStatus] = clientDetails.EmpoymentStatus ?? string.Empty;
            data["employer"] = clientDetails.Employer ?? string.Empty;
            data["businessNature"] = clientDetails.Industry ?? string.Empty;
            data["occupation"] = clientDetails.Occupation ?? string.Empty;

            var c = 1;
            foreach (var e in clientDetails.IdentityDetails)
            {
                data[$"type_{c}"] = e.IdentificationType ?? string.Empty;
                data[$"Country_{c}"] = e.CountryOfIssure ?? string.Empty;
                data[$"IdNo_{c}"] = e.IdentificationNumber ?? string.Empty;
                data[$"Expiry_{c}"] = e.ExpiryDate ?? string.Empty;
                c += 1;
            }

            // contact details
            data["unitNo"] = contactDetails.UnitNumber ?? string.Empty;
            data["streetNo"] = contactDetails.StreetNumber ?? string.Empty;
            data["suburb"] = contactDetails.Suburb ?? string.Empty;
            data["postalCode"] = contactDetails.PostalCode ?? string.Empty;
            data["complex"] = contactDetails.Complex ?? string.Empty;
            data["streetName"] = contactDetails.StreetName ?? string.Empty;
            data["city"] = contactDetails.City ?? string.Empty;
            data["country"] = contactDetails.Country ?? string.Empty;

            if (contactDetails.PostalInCareName == null)
                data["postalCare_False"] = "x";
            else
                data["postalCare_True"] = "x";
            data["careName"] = contactDetails.PostalInCareName ?? string.Empty;

            data["PA_AddressLine_1"] = $"{contactDetails.PA_UnitNumber ?? string.Empty} {contactDetails.PA_Complex ?? string.Empty}";
            data["PA_AddressLine_2"] = $"{contactDetails.PA_StreetNumber ?? string.Empty} {contactDetails.PA_StreetName ?? string.Empty}";
            data["PA_AddressLine_3"] = $"{contactDetails.Suburb ?? string.Empty}";
            data["PA_AddressLine_4"] = $"{contactDetails.City ?? string.Empty}";
            data["p_postalCode"] = $"{contactDetails.City ?? string.Empty}";
            data["p_country"] = $"{contactDetails.City ?? string.Empty}";
            data["work"] = contactDetails.WorkNumber ?? string.Empty;
            data["mobile"] = contactDetails.MobileNumber ?? string.Empty;
            data["Email"] = contactDetails.Email ?? string.Empty;

            // bank details
            data["accountHolder"] = $"{bv.Initials ?? string.Empty} {bv.Surname ?? string.Empty}";
            data["bank"] = bv.BankName ?? string.Empty;
            data["branchNo"] = bv.BranchCode ?? string.Empty;
            data["accountNo"] = bv.AccountNumber ?? string.Empty;
            data["accountType"] = bv.AccountType ?? string.Empty;

            // funding
            var sourceOfFundshOptions = new List<string>()
            {
                "monthlySalary", "commission", "bonus", "turnover", "annuity", "onceOffPayment",
                "salary", "Dividends", "interest", "bonuses"
            };

            if (sourceOfFundshOptions.Contains(funding.SourceOfFunds))
                data[funding.SourceOfFunds] = "x";
            else
                data["other"] = funding.SourceOfFunds;

            var sourceOfWealthOptions = new List<string>()
            {
                "savings", "investments", "shareSales", "propertySales",
                "companySales", "inheritance", "loan", "gift"
            };

            if (sourceOfWealthOptions.Contains(funding.SourceOfWealth))
                data[funding.SourceOfWealth] = "x";
            else
                data["Wealth_Other"] = funding.SourceOfWealth;

            // tax residency
            data["TaxNo"] = taxResidency.TaxNumber ?? string.Empty;
            data[taxResidency.TaxObligations == true ? "obligations_True" : "obligations_False"] = "x";
            data[taxResidency.UsCitizen == true ? "usCititzen_True" : "usCititzen_False"] = "x";
            data[taxResidency.UsRelinquished == true ? "usRelinquished_True" : "usRelinquished_False"] = "x";
            data[taxResidency.UsOther == true ? "usOther_True" : "usOther_False"] = "x";

            c = 1;
            foreach (var e in taxResidency.TaxResidencyItems)
            {
                data[$"Oblcountry_{c}"] = e.Country ?? string.Empty;
                data[$"TinNo_{c}"] = e.TinNumber ?? string.Empty;
                data[$"TXReason_{c}"] = e.TinUnavailableReason ?? string.Empty;
            }

            // declerations
            data["NameSurname"] = $"{clientDetails.FirstNames} {clientDetails.Surname}";
            data["SignerCapacity"] = "Self";
            data["DateSigned"] = DateTime.Today.ToShortDateString();

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("PrimaryIndividual.pdf", data),
                DocumentType = DocumentTypesEnum.PrimarySchedule
            };
        }

        private ApplicationDocumentsModel CreateBankValidationReport(BankVerificationsModel bv, string firstName, string lastName)
        {
            var data = new Dictionary<string, string>();

            data["bankName"] = bv.BankName ?? string.Empty;
            data["name"] = $"{firstName} {lastName}";
            data["searchDate"] = DateTime.Now.ToShortDateString();
            data["reference"] = bv.Reference;
            data["branchCode"] = bv.BranchCode ?? string.Empty;
            data["accountNumber"] = bv.AccountNumber ?? string.Empty;
            data["accountId"] = bv.AccountType;
            data["idNumber"] = bv.IdNumber ?? string.Empty;
            data["initials"] = bv.Initials ?? string.Empty;
            data["surname"] = bv.Surname ?? string.Empty;
            data["foundAtBank"] = bv.FoundAtBank ?? string.Empty;
            data["accOpen"] = bv.AccOpen ?? string.Empty;
            data["olderThan3Months"] = bv.OlderThan3Months ?? string.Empty;
            data["typeCorrect"] = bv.TypeCorrect ?? string.Empty;
            data["idNumberMatch"] = bv.IdNumberMatch ?? string.Empty;
            data["namesMatch"] = bv.InitialsMatch ?? string.Empty;
            data["acceptDebits"] = bv.AcceptDebits ?? string.Empty;
            data["acceptCredits"] = bv.AcceptCredits ?? string.Empty;

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("BankVerificationReport.pdf", data),
                DocumentType = DocumentTypesEnum.BankVerification
            };
        }

        private ApplicationDocumentsModel CreateFinancialNeedsAnalysis(RecordOfAdviseModel roa, string city,
            string firstName, string lastname, string idNumber, UserModel advisor)
        {
            var data = new Dictionary<string, string>();

            int c = 1;
            foreach (var prod in roa.SelectedProducts)
            {
                if (prod.DeveationReason == null)
                    data[$"prod{c}"] = prod.RecommendedLumpSum > 0 ?
                        $"{prod.ProductName}: R {prod.RecommendedLumpSum}, R {prod.RecommendedRecurringPremium}" :
                        $"{prod.ProductName}: R {prod.RecommendedLumpSum}";
                else
                    data[$"prod{c}"] = prod.AcceptedRecurringPremium > 0 ?
                        $"{prod.ProductName}: R {prod.AcceptedLumpSum}, R {prod.AcceptedRecurringPremium}" :
                        $"{prod.ProductName}: R {prod.AcceptedLumpSum}";
            }

            data["reason"] = $"After discussions with the client, and according to the risk profile " +
                $"the above investment/s were decided and agreed on.";
            data["signedAt"] = city;
            data["day"] = DateTime.Today.Day.ToString();
            data["monthYear"] = $"{DateTime.Today.Month}-{DateTime.Today.Year}";
            data["client"] = $"{firstName} {lastname} {idNumber}";
            data["advisor"] = $"{advisor.FirstName} {advisor.LastName} {advisor.IdNumber}";

            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("IntroLetter.pdf", data),
                DocumentType = DocumentTypesEnum.FinancialNeedsAnalysis
            };
        }

        private ApplicationDocumentsModel CreateIntroLetter(
            UserModel advisor, string firstName, string lastName, string IdNumber)
        {
            // create data dictionary
            var data = new Dictionary<string, string>();
            data["advisor"] = $"{advisor.FirstName} {advisor.LastName}";
            data["employmentDate"] = advisor.BrokerDetails.EmploymentDate.ToShortDateString();
            data["mobile"] = advisor.MobileNumber;
            data["email"] = advisor.Email;
            data["supervised"] = advisor.BrokerDetails.Supervised ? "supervised" : "not supervised";
            data["confirmation"] = $"{advisor.FirstName} {advisor.LastName}";
            data["client"] = $"{firstName} {lastName}";
            data["idNumber"] = IdNumber;
            data["date"] = DateTime.Today.ToShortDateString();

            // create document
            return new ApplicationDocumentsModel()
            {
                DocuemtnData = PopulateDocument("IntroLetter.pdf", data),
                DocumentType = DocumentTypesEnum.IntorLetter
            };
        }

        public ApplicationDocumentsModel PopulateTestDocument()
        {
            var data = new Dictionary<string, string>() {
                { "Text1", "Text box 1" },
                { "Text2", "Text box 2" },
                { "Text3", "Text box 3" },
            };

            return new ApplicationDocumentsModel() { DocuemtnData = PopulateDocument("FormIdTest.pdf", data) };
        }

        private byte[] PopulateDocument(string teplateName, Dictionary<string, string> formData)
        {
            char slash = Path.DirectorySeparatorChar;
            string templatePath = $"{_host.WebRootPath}{slash}pdf{slash}{teplateName}";

            var ms = new MemoryStream();
            var pdf = new PdfDocument(new PdfReader(templatePath), new PdfWriter(ms));
            var form = PdfAcroForm.GetAcroForm(pdf, true);
            IDictionary<String, PdfFormField> fields = form.GetFormFields();
            PdfFormField toSet;

            foreach (var d in formData)
            {
                try
                {
                    fields.TryGetValue(d.Key, out toSet);
                    toSet.SetValue(d.Value);
                }
                catch
                {
                    Console.WriteLine($"Form Field Error:  {d.Key}, {d.Value}");
                }
            }

            form.FlattenFields();
            pdf.Close();

            byte[] file = ms.ToArray();
            ms.Close();

            return file;
        }
    }
}