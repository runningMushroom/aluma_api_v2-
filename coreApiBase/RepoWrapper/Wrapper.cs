using MailSender;
using StringHasher;
using TokenProvider;
using vueBuilderApi.Data;
using vueBuilderApi.Interfaces;
using vueBuilderApi.Repositories;

namespace vueBuilderApi.RepoWrapper
{
    public class Wrapper : IWrapper
    {
        private DefaultDbContext _dbContext;
        private IUserRepo _user;
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