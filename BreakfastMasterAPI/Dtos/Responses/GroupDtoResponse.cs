using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Dtos.Responses
{
    public class GroupDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserDtoResponse> Users { get; set; }
    }
}
