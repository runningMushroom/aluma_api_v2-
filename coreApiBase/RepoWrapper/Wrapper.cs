using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Data;
using alumaApi.Repositories;
using BulkSms;

using JwtAuthentication;
using KycFactory;
using alumaApi.Repositories.Shedules;

namespace alumaApi.RepoWrapper
{
    public class Wrapper : IWrapper
    {
        private DefaultDbContext _dbContext;

        private IAdvisorAdvisedProductsRepo _advisorAdvisedProducts;
        private IAdvisorAdviseRepo _advisorAdvise;
        private IApplicationDocumentsRepo _applicationDocuments;
        private IApplicationRepo _application;
        private IApplicationStepRepo _applicationStep;
        private IBankVerificationRepo _bankVerification;
        private IRecordOfAdviseRepo _recordOfAdvise;
        private IRiskProfileRepo _riskProfile;
        private IOtpRepo _otp;
        private IUserRepo _user;

        // Schedules
        private IPrimaryIndividualRepo _primaryIndividual;

        private IBulkSmsRepo _bulkSMs;
        private IJwtRepo _jwt;
        private IKycFactoryRepo _kyc;
        private IStringHasher _hasher;
        private IMailSender _mailSender;
        private ITokenProvider _tokenProvider;

        public Wrapper(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IAdvisorAdvisedProductsRepo AdvisorAdvisedProducts
        {
            get { return _advisorAdvisedProducts == null ? new AdvisorAdvisedProductsRepo(_dbContext) : _advisorAdvisedProducts; }
        }

        public IAdvisorAdviseRepo AdvisorAdvise
        {
            get { return _advisorAdvise == null ? new AdvisorAdviseRepo(_dbContext) : _advisorAdvise; }
        }

        public IApplicationDocumentsRepo ApplicationDocuments
        {
            get { return _applicationDocuments == null ? new ApplicationDocumentsRepo(_dbContext) : _applicationDocuments; }
        }

        public IApplicationRepo Applications
        {
            get { return _application == null ? new ApplicationRepo(_dbContext) : _application; }
        }

        public IApplicationStepRepo ApplicationSteps
        {
            get { return _applicationStep == null ? new ApplicationStepRepo(_dbContext) : _applicationStep; }
        }

        public IBankVerificationRepo BankVerification
        {
            get { return _bankVerification == null ? new BankVerificationRepo(_dbContext) : _bankVerification; }
        }

        public IOtpRepo Otp
        {
            get { return _otp == null ? new OtpRepo(_dbContext) : _otp; }
        }

        public IRecordOfAdviseRepo RecordOfAdvise
        {
            get { return _recordOfAdvise == null ? new RecordOfAdviseRepo(_dbContext) : _recordOfAdvise; }
        }

        public IRiskProfileRepo RiskProfile
        {
            get { return _riskProfile == null ? new RiskProfileRepo(_dbContext) : _riskProfile; }
        }

        public IUserRepo User
        {
            get { return _user == null ? new UserRepo(_dbContext) : _user; }
        }

        // Primary Schedules

        public IPrimaryIndividualRepo PrimaryIndividual
        {
            get { return _primaryIndividual == null ? new PrimaryIndividualRepo(_dbContext) : _primaryIndividual; }
        }

        // non db
        public IBulkSmsRepo BulkSms
        {
            get { return _bulkSMs == null ? new BulkSmsRepo() : _bulkSMs; }
        }

        public IJwtRepo Jwt
        {
            get { return _jwt == null ? new JwtRepo() : _jwt; }
        }

        public IKycFactoryRepo KycFactory
        {
            get { return _kyc == null ? new KycFactoryRepo() : _kyc; }
        }

        public IStringHasher StrHasher
        {
            get { return _hasher == null ? new StringHasherRepo() : _hasher; }
        }

        public IMailSender SendMail
        {
            get { return _mailSender == null ? new MailSenderRepo() : _mailSender; }
        }

        public ITokenProvider TokenProvider
        {
            get { return _tokenProvider == null ? new TokenProviderRepo() : _tokenProvider; }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}