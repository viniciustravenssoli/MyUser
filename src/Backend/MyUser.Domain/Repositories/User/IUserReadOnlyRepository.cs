using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Domain.Repositories.User;
public interface IUserReadOnlyRepository
{
    Task<bool> ExistUserWithEmail(string email);
    Task<Entities.User> GetByEmailAndPassword(string email, string password);
    Task<Entities.User> GetByEmail(string email);
}
