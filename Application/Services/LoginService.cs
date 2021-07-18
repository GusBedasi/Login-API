using System;
using Application.DTO.Contracts;
using Application.DTO.Response;
using Application.Helpers;
using Application.Interfaces;
using Application.Tokens;
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

        public LoginResponse Login(ILogin request)
        {
            var user = ValidateUser(request.Username, request.Password);

            if (user == null)
            {
                throw new NotFoundException();
            }

            var token = TokenService.GenerateToken(user);

            var loginResponse = new LoginResponse()
            {
                Username = request.Username,
                Token = token
            };

            return loginResponse;
        }

        public User GetUserByUsername(string username)
        {
            var user = _userRepository.FindOne(x => x.Username == username);

            return user;
        }

        private void CheckIfUserExists(string username)
        {
            var userExists = _userRepository.FindOne(x => x.Username == username);

            if (userExists != null)
            {
                throw new PreconditionFailedException("This user already exists");
            }
        }

        private User ValidateUser(string username, string password)
        {
            var user = _userRepository.FindOne(x => x.Username == username);

            Encrypter.Decrypt(password, user.CryptedPassword);

            return user;
        }
    }
}