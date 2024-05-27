using MyUser.Domain.Repositories.Address;
using MyUser.Infra.Context.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Infra.Context.Repositories.Address;
public class AddressRepository : IAddressReadOnlyRepository, IAddressWriteOnlyRepository
{
    private readonly MyUserDbContext _context;

    public AddressRepository(MyUserDbContext context)
    {
        _context = context;
    }

    public Task Add(Domain.Entities.Address user)
    {
        throw new NotImplementedException();
    }
}
