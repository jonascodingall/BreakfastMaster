using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Services
{
    public interface IBreadRollService
    {
        // CRUD
        Task CreateBreadRoll(BreadRollModel breadRoll); // Create
        Task<IEnumerable<BreadRollModel>> ReadBreadRoll(); // Read
        Task<BreadRollModel> ReadBreadRolls(int breadRollId); // Read
        Task UpdateBreadRoll(int breadRollId, BreadRollModel newBreadRoll); // Update
        Task DeleteBreadRoll(int breadRollId); // Delete
    }
}
