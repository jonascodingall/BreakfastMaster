using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Dtos.Requests
{
    public class UserDtoRequest
    {
        public string Name { get; set; }
        public int GroupId {  get; set; }
    }
}
