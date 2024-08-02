using MyUser.Communication.User.Requests;
using MyUser.Domain.Repositories.User;
using MyUser.Infra.DTOs;
using MyUser.Infra.Services;
using MyUser.Infra.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyUser.Application.User
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICepService _cepService;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public UserService(IUnitOfWork unitOfWork, ICepService cepService, IUserWriteOnlyRepository userWriteOnlyRepository, IUserReadOnlyRepository userReadOnlyRepository)
        {
            _unitOfWork = unitOfWork;
            _cepService = cepService;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task CreateUser(CreateUserRequest request)
        {
            var usuarioExist = await _userReadOnlyRepository.ExistUserWithEmail(request.Email);
            if (usuarioExist)
            {
                throw new ArgumentException("Já existe um usuário com este email");
            }

            ResponseCepDto responseCep = await _cepService.BuscaCep(request.CEP);

            var addresses = ConvertToAddresses(responseCep);

            var user = new Domain.Entities.User
            {
                Email = request.Email,
                Name = request.Name,
                Password = request.Password,
                Phone = request.Phone,
                Addresses = addresses
            };

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();
        }

        private ICollection<Domain.Entities.Address> ConvertToAddresses(ResponseCepDto responseCep)
        {
          
            return new List<Domain.Entities.Address>
            {
                new Domain.Entities.Address
                {
                    Street = responseCep.Logradouro,
                    City = responseCep.Localidade,
                    State = responseCep.Uf,
                    ZipCode = responseCep.Cep,
                }
            };
        }
    }
}
