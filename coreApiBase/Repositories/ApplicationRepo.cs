using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IApplicationRepo : IRepoBase<ApplicationsModel>
    {
    }

    public class ApplicationRepo : RepoBase<ApplicationsModel>, IApplicationRepo
    {
        public ApplicationRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}