using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IFspMandateRepo : IRepoBase<FspMandateModel>
    {
    }

    public class FspMandateRepo : RepoBase<FspMandateModel>, IFspMandateRepo
    {
        public FspMandateRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}