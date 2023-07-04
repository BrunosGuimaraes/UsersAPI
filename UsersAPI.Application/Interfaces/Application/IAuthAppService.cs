using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersAPI.Application.Interfaces.Application
{
    public interface IAuthAppService : IDisposable
    {
        LoginResponseDto Login(LoginRequestDto loginRequestDto);
        UserResponseDto ForgotPassword(ForgotPasswordRequestDto forgotPasswordRequestDto);
        UserResponseDto ResetPassword(Guid id, ResetPasswordRequestDto resetPasswordRequestDto);
    }
}
