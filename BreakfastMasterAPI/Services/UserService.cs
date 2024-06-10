using BreakfastMasterAPI.Models;
using BreakfastMasterAPI.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BreakfastMasterAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<UserModel> _userRepository;
        private readonly IRepositoryAsync<UserBreadRollModel> _userBreadRollRepository;

        public UserService(IRepositoryAsync<UserModel> userRepository, IRepositoryAsync<UserBreadRollModel> userBreadRollRepository)
        {
            _userRepository = userRepository;
            _userBreadRollRepository = userBreadRollRepository;
        }

        // CRUD
        public async Task CreateUser(UserModel user)
        {
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();
        }
        public async Task DeleteUser(int userId)
        {
            var user = await _userRepository.GetAsync(userId);
            _userRepository.Remove(user);
            await _userRepository.SaveChangesAsync();
        }
        public async Task<UserModel> ReadUser(int userId)
        {
            return await _userRepository.GetAsync(userId);
        }
        public async Task<IEnumerable<UserModel>> ReadUsers()
        {
            return await _userRepository.GetAllAsync();
        }
        public async Task UpdateUser(int userId, UserModel newUser)
        {
            var user = await _userRepository.GetAsync(userId);
            user.Name = newUser.Name;
            user.GroupId = newUser.GroupId;
            user.Group = newUser.Group;
            user.UserBreadRolls = newUser.UserBreadRolls;
            await _userRepository.SaveChangesAsync();
        }

        // ADD REMOVE BREADROLL
        public async Task AddBreadRollToUser(int userId, int breadRollId)
        {
            var userBreadRoll = _userBreadRollRepository.Find(ub => ub.UserId == userId && ub.BreadRollId == breadRollId).FirstOrDefault();

            if (userBreadRoll != null)
            {
                userBreadRoll.Count++;
            }
            else
            {
                userBreadRoll = new UserBreadRollModel
                {
                    UserId = userId,
                    BreadRollId = breadRollId,
                    Count = 1
                };
                await _userBreadRollRepository.AddAsync(userBreadRoll);
            }

            await _userBreadRollRepository.SaveChangesAsync();
        }
        public async Task RemoveBreadRollFromUser(int userId, int breadRollId)
        {
            var userBreadRoll = _userBreadRollRepository.Find(ub => ub.UserId == userId && ub.BreadRollId == breadRollId).FirstOrDefault();

            if (userBreadRoll != null)
            {
                if (userBreadRoll.Count > 1)
                {
                    userBreadRoll.Count--;
                }
                else
                {
                    _userBreadRollRepository.Remove(userBreadRoll);
                }

                await _userBreadRollRepository.SaveChangesAsync();
            }
        }
    }
}
