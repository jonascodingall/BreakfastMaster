using AutoMapper;
using BreakfastMasterAPI.Dtos.Requests;
using BreakfastMasterAPI.Dtos.Responses;
using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.MapperProfiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserDtoRequest, UserModel>();
            CreateMap<UserModel, UserDtoResponse>();
        }
    }
}
