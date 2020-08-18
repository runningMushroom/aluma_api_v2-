using alumaApi.Data;
using alumaApi.Models;

namespace alumaApi.Repositories
{
    public interface IUserRepo : IRepoBase<UserModel>
    {
    }

    public class UserRepo : RepoBase<UserModel>, IUserRepo
    {
        public UserRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}