using vueBuilderApi.Data;
using vueBuilderApi.Interfaces;
using vueBuilderApi.Models;

namespace vueBuilderApi.Repositories
{
    public class UserRepo : RepoBase<UserModel>, IUserRepo
    {
        public UserRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}