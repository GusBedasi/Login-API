using Application.DTO.Response;
using Domain.Aggregates.UserAgg.Entities;

namespace Service.API.Mappers
{
    public static class UserMapper
    {
        public static CreateUserResponse MapDTOToCreateRecipientResponse(User result)
        {
            var createdUserResponse = new CreateUserResponse()
            {
                ExternalId = result.ExternalId,
                Name = result.Name,
                Username = result.Username,
                Birthday = result.Birthday,
                CreatedAt = result.CreatedAt,
                UpdatedAt = result.UpdatedAt,
                Active =  result.Active
            };

            return createdUserResponse;
        }
    }
}