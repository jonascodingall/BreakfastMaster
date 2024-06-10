using BreakfastMasterAPI.Models;

namespace BreakfastMasterAPI.Services
{
    public interface IUserService
    {
        // CRUD
        Task CreateUser(UserModel user); // Create
        Task<IEnumerable<UserModel>> ReadUsers(); // Read
        Task<UserModel> ReadUser(int userId); // Read
        Task UpdateUser(int userId, UserModel newUser); // Update
        Task DeleteUser(int userId); // Delete

        // Other
        Task AddBreadRollToUser(int userId, int breadRollId);
        Task RemoveBreadRollFromUser(int userId, int breadRollId);
    }
}
