using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Data;
using alumaApi.Repositories;
using BulkSms;

using JwtAuthentication;

namespace alumaApi.RepoWrapper
{
    public class Wrapper : IWrapper
    {
        private DefaultDbContext _dbContext;

        private IAdvisorAdvisedProductsRepo _advisorAdvisedProducts;
        private IAdvisorAdviseRepo _advisorAdvise;
        private IApplicationRepo _application;
        private IApplicationStepRepo _applicationStep;
        private IOtpRepo _otp;
        private IUserRepo _user;

        private IBulkSmsRepo _bulkSMs;
        private IJwtRepo _jwt;
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

        public IApplicationRepo Applications
        {
            get { return _application == null ? new ApplicationRepo(_dbContext) : _application; }
        }

        public IApplicationStepRepo ApplicationSteps
        {
            get { return _applicationStep == null ? new ApplicationStepRepo(_dbContext) : _applicationStep; }
        }

        public IOtpRepo Otp
        {
            get { return _otp == null ? new OtpRepo(_dbContext) : _otp; }
        }

        public IUserRepo User
        {
            get { return _user == null ? new UserRepo(_dbContext) : _user; }
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