using System;
using Application.DTO.Contracts;
using Application.DTO.Response;
using Application.Helpers;
using Application.Interfaces;
using Domain.Aggregates.UserAgg.Entities;
using Domain.Exceptions;
using Domain.Seedwork;
using Infrastructure.Data.Interfaces;

namespace Application.Services
{
    public class LoginService : ILoginService
    {
        private IUserRepository _userRepository;
        public LoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User CreateUser(ICreateUser request)
        {
            CheckIfUserExists(request.Username);

            var cryptedPassword = Encrypter.Crypt(request.Password);

            var user = new User(request, cryptedPassword);
            
            _userRepository.Add(user);

            return user;
        }

        public User UpdateUser(IUpdateUser request)
        {
            throw new System.NotImplementedException();
        }

        public void Login(ILogin request)
        {
            throw new System.NotImplementedException();
        }

        public void Logout()
        {
            throw new System.NotImplementedException();
        }

        public void OnlyTokenAccess()
        {
            throw new System.NotImplementedException();
        }

        private void CheckIfUserExists(string username)
        {
            var userExists = _userRepository.FindOne(x => x.Username == username);

            if (userExists != null)
            {
                throw new PreconditionFailedException("This user already exists");
            }
        }
    }
}