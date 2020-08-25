using alumaApi.Data;
using alumaApi.Models;

namespace alumaApi.Repositories
{
    public interface IBankVerificationRepo : IRepoBase<BankVerificationsModel>
    {
    }

    public class BankVerificationRepo : RepoBase<BankVerificationsModel>, IBankVerificationRepo
    {
        public BankVerificationRepo(DefaultDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}