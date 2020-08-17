using MailSender;
using StringHasher;
using TokenProvider;
using vueBuilderApi.Interfaces;

namespace vueBuilderApi.RepoWrapper
{
    public interface IWrapper
    {
        // from entities
        IUserRepo User { get; }

        // from other sources
        IStringHasher StrHasher { get; }

        IMailSender SendMail { get; }
        ITokenProvider TokenProvider { get; }

        void Save();
    }
}