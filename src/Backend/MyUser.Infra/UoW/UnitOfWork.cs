using MyUser.Infra.Context.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Infra.UoW;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly MyUserDbContext _context;
    private bool _disposed;
    public UnitOfWork(MyUserDbContext context)
    {
        _context = context;
    }

    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
}