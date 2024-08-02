using Microsoft.EntityFrameworkCore;
using MyUser.Domain.Entities;
using MyUser.Domain.Repositories.User;
using MyUser.Infra.Context.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Infra.Context.Repositories.User;
public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly MyUserDbContext _context;

    public UserRepository(MyUserDbContext context)
    {
        _context = context;
    }

    public async Task Add(Domain.Entities.User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<bool> ExistUserWithEmail(string email)
    {
        return await _context.Users.AnyAsync(x => x.Email.Equals(email));
    }

    public async Task<Domain.Entities.User> GetByEmail(string email)
    {
        return await _context.Users
              .Include(u => u.Addresses)
              .FirstOrDefaultAsync(x => x.Email.Equals(email));
    }

    public async Task<Domain.Entities.User> GetByEmailAndPassword(string email, string password)
    {
        return await _context.Users
               .FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password == password);
    }
}
