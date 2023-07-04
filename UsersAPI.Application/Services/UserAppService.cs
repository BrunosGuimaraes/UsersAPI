using AutoMapper;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Application.Interfaces.Application;
using UsersAPI.Domain.Entities;
using UsersAPI.Domain.Interfaces.Services;

namespace UsersAPI.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserDomainService? userDomainService;
        private readonly IMapper? mapper;
        public UserAppService(IUserDomainService? userDomainService, IMapper? mapper)
        {
            this.userDomainService = userDomainService;
            this.mapper = mapper;
        }

        public UserResponseDto Add(UserAddRequestDto userDto)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                CreatedAt = DateTime.Now
            };

            userDomainService?.Add(user);

            return mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Update(Guid id, UserUpdateRequestDto userDto)
        {
            var user = userDomainService?.Get(id);

            if (user == null) return null;

            user.Name = userDto.Name;

            userDomainService?.Update(user);

            return mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Delete(Guid id)
        {
            var user = userDomainService?.Get(id);

            if (user == null) return null;

            userDomainService?.Delete(user);

            return mapper.Map<UserResponseDto>(user);
        }

        public UserResponseDto Get(Guid id)
        {
            var user = userDomainService?.Get(id);

            return mapper.Map<UserResponseDto>(user);
        }

        public void Dispose()
        {
            userDomainService?.Dispose();
        }
    }
}
