using AutoMapper;
using UsersAPI.Application.Dtos.Responses;
using UsersAPI.Domain.Entities;

namespace UsersAPI.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserResponseDto>().ReverseMap();
            //.AfterMap((entity, dto) =>
            //{
            //    dto.Id = entity.Id;
            //    dto.Name = entity.Name;
            //    dto.Email = entity.Email;
            //    dto.CreatedAt = entity.CreatedAt;

            //})


        }
    }
}
