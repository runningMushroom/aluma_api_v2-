﻿using MailSender;
using StringHasher;
using TokenProvider;
using BulkSms;
using JwtAuthentication;
using alumaApi.Repositories;

namespace alumaApi.RepoWrapper
{
    public interface IWrapper
    {
        IApplicationRepo Applications { get; }
        IApplicationStepRepo ApplicationSteps { get; }
        IOtpRepo Otp { get; }
        IUserRepo User { get; }

        // from other sources
        IBulkSmsRepo BulkSms { get; }

        IJwtRepo Jwt { get; }
        IStringHasher StrHasher { get; }
        IMailSender SendMail { get; }
        ITokenProvider TokenProvider { get; }

        void Save();
    }
}