using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Data;
using alumaApi.Interfaces;
using alumaApi.Repositories;
using BulkSms;

using alumaApi.Interfaces;

namespace alumaApi.RepoWrapper
{
    public class Wrapper : IWrapper
    {
        private DefaultDbContext _dbContext;
        private IOtpRepo _otp;
        private IUserRepo _user;
        private IBulkSmsRepo _bulkSMs;
        private IStringHasher _hasher;
        private IMailSender _mailSender;
        private ITokenProvider _tokenProvider;

        public Wrapper(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
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