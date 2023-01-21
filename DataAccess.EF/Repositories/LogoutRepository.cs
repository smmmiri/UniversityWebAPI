using Domain.Entities;
using Repository.Interfaces;

namespace Repository.Repositories
{
    public class LogoutRepository : ILogoutRepository
    {
        private readonly AcademyDbContext _academy;
        public LogoutRepository(AcademyDbContext academy)
        {
            _academy = academy;
        }

        public void AddToBlackList(string token)
        {
            ExpiredToken expiredToken = new()
            {
                Token = token
            };
            _academy.Set<ExpiredToken>().Add(expiredToken);
            _academy.SaveChanges();
        }
    }
}
