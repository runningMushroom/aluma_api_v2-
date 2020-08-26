using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IRiskProfileRepo : IRepoBase<RiskProfileModel>
    {
    }

    public class RiskProfileRepo : RepoBase<RiskProfileModel>, IRiskProfileRepo
    {
        public RiskProfileRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}