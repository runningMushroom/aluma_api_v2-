using alumaApi.Data;
using alumaApi.Enum;
using alumaApi.Models;
using iText.Forms;
using iText.Forms.Fields;
using iText.Kernel.Pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace alumaApi.Repositories
{
    public interface IApplicationRepo : IRepoBase<ApplicationsModel>
    {
    }

    public class ApplicationRepo : RepoBase<ApplicationsModel>, IApplicationRepo
    {
        private readonly DefaultDbContext _context;

        public ApplicationRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
            _context = databaseContext;
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

            // get the schedule

            // create intro letter (every application will require one)
            if (appl.Documents.Any(c => c.DocumentType == DocumentTypesEnum.IntorLetter))
            {
                ApplicationDocumentsModel introLetter = null;
                if (kycExist)
                    introLetter = CreateIntroLetter(appl.User, kyc.FirstNames, kyc.SurName, kyc.IdNumber);
                else
                    introLetter = CreateIntroLetter(appl.User, appl.User.FirstName, appl.User.LastName, appl.User.IdNumber);

                introLetter.ApplicationId = appl.Id;
                introLetter.Name = $"Intro Letter: {appl.User.FirstName} {appl.User.LastName}";
                _context.ApplicationDocuments.Add(introLetter);
                _context.SaveChanges();
            }

            // create FNA (every application will require one)
            if (appl.Documents.Any(c => c.DocumentType == DocumentTypesEnum.FinancialNeedsAnalysis))
            {
            }
        }

        private ApplicationDocumentsModel FinancialNeedsAnalysis(RecordOfAdviseModel roa, string city,
            string firstName, string lastname, string idNumber, UserModel advisor)
        {
            var data = new Dictionary<string, string>();

            int c = 1;
            foreach (var prod in roa.SelectedProducts)
            {
                // client didn't accept the reccomended values
                //if (prod.DeveationReason != null)
                //    data[$"prod{c}"] = $"{prod.ProductName}: R{prod.}";
            }

            return new ApplicationDocumentsModel() { DocuemtnData = PopulateDocument("IntroLetter.pdf", data) };
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
            return new ApplicationDocumentsModel() { DocuemtnData = PopulateDocument("IntroLetter.pdf", data) };
        }

        private byte[] PopulateDocument(string teplateName, Dictionary<string, string> formData)
        {
            HostingEnvironment host = new HostingEnvironment();
            char slash = Path.DirectorySeparatorChar;
            string templatePath = $"{host.ContentRootPath}{slash}wwwroot{slash}pdf{slash}{teplateName}";

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