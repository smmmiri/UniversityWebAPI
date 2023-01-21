using Domain;
using Message.Commands;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public AccountRepository(AcademyDbContext academy)
        {
        }
    }
}
