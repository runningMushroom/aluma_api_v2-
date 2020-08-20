using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IAdvisorAdvisedProductsRepo : IRepoBase<AdvisorAdvisedProductsModel>
    {
    }

    public class AdvisorAdvisedProductsRepo : RepoBase<AdvisorAdvisedProductsModel>, IAdvisorAdvisedProductsRepo
    {
        public AdvisorAdvisedProductsRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}