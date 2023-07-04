using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface IUserAppService : IDisposable
    {
        UserResponseDto Add(UserAddRequestDto userAddRequestDto);
        UserResponseDto Update(Guid id, UserUpdateRequestDto userUpdateRequestDto);
        UserResponseDto Delete(Guid id);
        UserResponseDto Get(Guid id);
    }
}
