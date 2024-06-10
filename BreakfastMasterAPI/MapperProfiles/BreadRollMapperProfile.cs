using AutoMapper;
using BreakfastMasterAPI.Dtos.Requests;
using BreakfastMasterAPI.Dtos.Responses;
using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.MapperProfiles
{
    public class BreadRollMapperProfile : Profile
    {
        public BreadRollMapperProfile()
        {
            CreateMap<BreadRollDtoRequest, BreadRollModel>();
            CreateMap<BreadRollModel, BreadRollDtoResponse>();
        }
    }
}
