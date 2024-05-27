using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Infra.UoW;
public interface IUnitOfWork
{
    Task Commit();
}
