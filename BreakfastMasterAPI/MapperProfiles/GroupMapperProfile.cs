using AutoMapper;
using BreakfastMasterAPI.Dtos.Requests;
using BreakfastMasterAPI.Dtos.Responses;
using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.MapperProfiles
{
    public class GroupMapperProfile : Profile
    {
        public GroupMapperProfile()
        {
            CreateMap<GroupDtoRequest, GroupModel>();
            CreateMap<GroupModel, GroupDtoResponse>();
        }
    }
}
