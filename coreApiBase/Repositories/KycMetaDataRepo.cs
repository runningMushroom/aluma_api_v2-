using alumaApi.Data;
using alumaApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories
{
    public interface IKycMetaDataRepo : IRepoBase<KycMetaDataModel>
    {
    }

    public class KycMetaDataRepo : RepoBase<KycMetaDataModel>, IKycMetaDataRepo
    {
        public KycMetaDataRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}