using MyUser.Infra.DTOs;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUser.Infra.Services;
public interface ICepService
{
    [Get("/{cep}/json/")]
    Task<ResponseCepDto> BuscaCep(string cep);
}
