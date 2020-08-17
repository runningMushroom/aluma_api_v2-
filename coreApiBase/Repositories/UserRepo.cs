using alumaApi.Data;
using alumaApi.Interfaces;
using alumaApi.Models;

namespace alumaApi.Repositories
{
    public class UserRepo : RepoBase<UserModel>, IUserRepo
    {
        public UserRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}