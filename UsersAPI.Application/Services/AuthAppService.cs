using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Exceptions;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Application.Services
{
    public class AuthAppService : IAuthAppService
    {
        private readonly IUserDomainService userDomainService;
        private readonly IMapper mapper;
        public AuthAppService(IUserDomainService userDomainService, IMapper mapper)
        {
            this.userDomainService = userDomainService;
            this.mapper = mapper;
        }

        public LoginResponseDto Login(LoginRequestDto loginRequestDto)
        {
            try
            {
                var token = userDomainService?.Authenticate(loginRequestDto.Email, loginRequestDto.Password);

                return new LoginResponseDto
                {
                    AcessToken = token,
                };
            }
            catch (AccessDeniedException aex)
            {
                throw new ApplicationException(aex.Message) ;
            }
        }

        public UserResponseDto ForgotPassword(ForgotPasswordRequestDto forgotPasswordDto)
        {
            var user = userDomainService.Get(forgotPasswordDto.Email);
            //TODO: Implementar regra de forgot
            return mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto ResetPassword(Guid id, ResetPasswordRequestDto resetPasswordRequestDto)
        {
            var user = userDomainService.Get(id);
            //TODO: Implementar regra de reset
            return mapper.Map<UserResponseDto>(user);
        }
        public void Dispose()
        {
            userDomainService.Dispose();
        }

    }
}
