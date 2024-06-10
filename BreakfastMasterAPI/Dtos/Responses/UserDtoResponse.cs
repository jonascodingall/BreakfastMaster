using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Dtos.Responses
{
    public class UserDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserBreadRollDtoResponse> UserBreadRolls { get; set; }
    }
}
