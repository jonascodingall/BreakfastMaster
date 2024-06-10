using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Services
{
    public interface IGroupService
    {
        // CRUD
        Task CreateGroup(GroupModel group); // Create
        Task<IEnumerable<GroupModel>> ReadGroups(); // Read
        Task<GroupModel> ReadGroup(int groupId); // Read
        Task UpdateGroup(int groupId, GroupModel newGroup); // Update
        Task DeleteGroup(int groupId); // Delete
    }
}
