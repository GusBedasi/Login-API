using Application.DTO.Contracts;
using Application.DTO.Response;
using Domain.Aggregates.UserAgg.Entities;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        User CreateUser(ICreateUser request);
        LoginResponse Login(ILogin request);
        User GetUserByUsername(string username);
    }
}