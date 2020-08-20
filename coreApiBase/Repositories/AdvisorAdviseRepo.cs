using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IAdvisorAdviseRepo : IRepoBase<AdvisorAdviseModel>
    {
    }

    public class AdvisorAdviseRepo : RepoBase<AdvisorAdviseModel>, IAdvisorAdviseRepo
    {
        public AdvisorAdviseRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}