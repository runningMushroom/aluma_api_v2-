using alumaApi.Data;
using alumaApi.Models;

namespace alumaApi.Repositories
{
    public interface IOtpRepo : IRepoBase<OtpModel>
    {
    }

    public class OtpRepo : RepoBase<OtpModel>, IOtpRepo
    {
        public OtpRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}