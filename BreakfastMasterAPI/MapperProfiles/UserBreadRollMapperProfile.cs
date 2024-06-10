using AutoMapper;
using BreakfastMasterAPI.Dtos.Responses;
using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.MapperProfiles
{
    public class UserBreadRollMapperProfile : Profile
    {
        public UserBreadRollMapperProfile()
        {
            CreateMap<UserBreadRollModel, UserBreadRollDtoResponse>();
        }
    }
}
