using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Interfaces;
using BulkSms;

namespace alumaApi.RepoWrapper
{
    public interface IWrapper
    {
        // from entities
        IUserRepo User { get; }

        // from other sources
        IBulkSmsRepo BulkSms { get; }

        IStringHasher StrHasher { get; }
        IMailSender SendMail { get; }
        ITokenProvider TokenProvider { get; }

        void Save();
    }
}