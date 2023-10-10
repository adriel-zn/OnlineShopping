using OnlineShopping.Data.Entities;
using OnlineShopping.Data;
using OnlineShopping.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace OnlineShopping.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> AuthenticateUser(string username, string password)
        {
            var user = await _context.Users.FirstAsync(x => x.Username == username && x.Password == password);

            if (user != null)
                user.Role = await _context.UserRoles.FirstAsync(x => x.Id == user.RoleId);

            return user;
        }
    }
}
