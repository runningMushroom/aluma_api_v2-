using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IDividendTaxRepo : IRepoBase<DividendTaxModel>
    {
    }

    public class DividendTaxRepo : RepoBase<DividendTaxModel>, IDividendTaxRepo
    {
        public DividendTaxRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}