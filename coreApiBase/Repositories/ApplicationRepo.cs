using alumaApi.Data;
using alumaApi.Models;

namespace alumaApi.Repositories
{
    public interface IApplicationRepo : IRepoBase<ApplicationsModel>
    {
    }

    public class ApplicationRepo : RepoBase<ApplicationsModel>, IApplicationRepo
    {
        public ApplicationRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}