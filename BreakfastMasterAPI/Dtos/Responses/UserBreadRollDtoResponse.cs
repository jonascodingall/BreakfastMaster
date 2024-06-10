using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Dtos.Responses
{
    public class UserBreadRollDtoResponse
    {
        public BreadRollDtoResponse BreadRoll { get; set; }
        public int Count { get; set; }
    }
}
