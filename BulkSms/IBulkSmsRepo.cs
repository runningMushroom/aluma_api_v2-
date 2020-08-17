using System;
using System.Linq;
using System.Threading.Tasks;

namespace BulkSms
{
    public interface IBulkSmsRepo
    {
        string CreateOtp();

        bool SendOtop(string mobile, string message);
    }
}