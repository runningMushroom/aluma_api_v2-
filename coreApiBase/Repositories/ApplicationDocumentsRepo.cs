using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IApplicationDocumentsRepo : IRepoBase<ApplicationDocumentsModel>
    {
    }

    public class ApplicationDocumentsRepo : RepoBase<ApplicationDocumentsModel>, IApplicationDocumentsRepo
    {
        public ApplicationDocumentsRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}