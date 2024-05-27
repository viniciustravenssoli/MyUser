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

    public Task Add(Domain.Entities.User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistUserWithEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.User> GetByEmail(string email)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Entities.User> GetByEmailAndPassword(string email, string password)
    {
        throw new NotImplementedException();
    }
}
