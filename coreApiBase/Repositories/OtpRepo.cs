using alumaApi.Data;
using alumaApi.Interfaces;
using alumaApi.Models;

using alumaApi.Interfaces;
using alumaApi.Models;

namespace alumaApi.Repositories
{
    public class OtpRepo : RepoBase<OtpModel>, IOtpRepo
    {
        public OtpRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}