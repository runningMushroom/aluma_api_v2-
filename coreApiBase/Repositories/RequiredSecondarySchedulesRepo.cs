using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IRequiredSecondarySchedulesRepo : IRepoBase<RequiredSecondarySchedulesModel>
    {
    }

    public class RequiredSecondarySchedulesRepo : RepoBase<RequiredSecondarySchedulesModel>, IRequiredSecondarySchedulesRepo
    {
        public RequiredSecondarySchedulesRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}