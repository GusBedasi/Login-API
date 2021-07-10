using Application.DTO.Contracts;
using Domain.Aggregates.UserAgg.Entities;

namespace Application.Interfaces
{
    public interface ILoginService
    {
        User CreateUser(ICreateUser request);
        User UpdateUser(IUpdateUser request);
        void Login(ILogin request);
        void Logout();
        void OnlyTokenAccess();
    }
}