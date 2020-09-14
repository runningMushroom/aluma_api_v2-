using alumaApi.Data;
using alumaApi.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories.Shedules
{
    public interface IPrimaryTrustRepo : IRepoBase<PrimaryTrustModel>
    {
    }

    public class PrimaryTrustRepo : RepoBase<PrimaryTrustModel>, IPrimaryTrustRepo
    {
        public PrimaryTrustRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}