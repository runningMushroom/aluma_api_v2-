using MailSender;
using StringHasher;
using TokenProvider;
using alumaApi.Interfaces;
using BulkSms;

using alumaApi.Interfaces;

namespace alumaApi.RepoWrapper
{
    public interface IWrapper
    {
        IOtpRepo Otp { get; }
        IUserRepo User { get; }

        // from other sources
        IBulkSmsRepo BulkSms { get; }

        IStringHasher StrHasher { get; }
        IMailSender SendMail { get; }
        ITokenProvider TokenProvider { get; }

        void Save();
    }
}