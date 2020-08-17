using System;
using System.Linq;

namespace BulkSms
{
    public interface IBulkSmsRepo
    {
        string CreateOtp();
    }
}