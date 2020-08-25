using alumaApi.Data;
using alumaApi.Models.Schedules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alumaApi.Repositories.Shedules
{
    public interface IPrimaryIndividualRepo : IRepoBase<PrimaryIndividualModel>
    {
    }

    public class PrimaryIndividualRepo : RepoBase<PrimaryIndividualModel>, IPrimaryIndividualRepo
    {
        public PrimaryIndividualRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}