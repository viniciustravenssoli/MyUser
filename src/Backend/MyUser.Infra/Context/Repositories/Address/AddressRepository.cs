using MyUser.Domain.Entities;
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

    public async Task Add(Domain.Entities.Address address)
    {
        await _context.Addresses.AddAsync(address);
    }
}
