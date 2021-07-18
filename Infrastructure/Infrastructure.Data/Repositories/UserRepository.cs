using Domain.Aggregates.UserAgg.Entities;
using Infrastructure.Data.Context;
using Infrastructure.Data.Interfaces;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LoginDbContext context) : base(context)
        { }
    }
}