using vueBuilderApi.Data;
using vueBuilderApi.Interfaces;
using vueBuilderApi.Models;

namespace vueBuilderApi.Repositories
{
    public class SystemUserRepo : RepoBase<SystemUserModel>, ISystemUserRepo
    {
        public SystemUserRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}