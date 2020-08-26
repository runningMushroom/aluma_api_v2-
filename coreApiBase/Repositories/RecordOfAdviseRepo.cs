using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IRecordOfAdviseRepo : IRepoBase<RecordOfAdviseModel>
    {
    }

    public class RecordOfAdviseRepo : RepoBase<RecordOfAdviseModel>, IRecordOfAdviseRepo
    {
        public RecordOfAdviseRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}