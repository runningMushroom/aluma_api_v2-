using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Data;
using alumaApi.Interfaces;
using alumaApi.Repositories;
using BulkSms;

namespace alumaApi.RepoWrapper
{
    public class Wrapper : IWrapper
    {
        private DefaultDbContext _dbContext;
        private IUserRepo _user;
        private IBulkSmsRepo _bulkSMs;
        private IStringHasher _hasher;
        private IMailSender _mailSender;
        private ITokenProvider _tokenProvider;

        public Wrapper(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
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