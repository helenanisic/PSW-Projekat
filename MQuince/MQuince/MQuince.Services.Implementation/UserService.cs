using System;
using System.Collections.Generic;
using System.Text;
using MQuince.Repository.Contracts;
using MQuince.Services.Contracts.DTO;
using MQuince.Services.Contracts.DTO.Users;
using MQuince.Services.Contracts.IdentifiableDTO;
using MQuince.Services.Contracts.Interfaces;

namespace MQuince.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Guid AuthenticateUser(UserLoginDTO user)
        {
            return _userRepository.AuthenticateUser(user);
        }

        public Guid Create(UserDTO entityDTO)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IdentifiableDTO<UserDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IdentifiableDTO<UserDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(UserDTO entityDTO, Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
