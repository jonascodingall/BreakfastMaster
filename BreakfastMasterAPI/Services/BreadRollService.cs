using BreakfastMasterAPI.Models;
using BreakfastMasterAPI.Repositories;

namespace BreakfastMasterAPI.Services
{
    public class BreadRollService : IBreadRollService
    {
        private readonly IRepositoryAsync<BreadRollModel> _repositoryAsync;
        public BreadRollService(IRepositoryAsync<BreadRollModel> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task CreateBreadRoll(BreadRollModel breadRoll)
        {
            await _repositoryAsync.AddAsync(breadRoll);
            await _repositoryAsync.SaveChangesAsync();
        }

        public async Task DeleteBreadRoll(int breadRollId)
        {
            var breadRoll = await _repositoryAsync.GetAsync(breadRollId);
            _repositoryAsync.Remove(breadRoll);
            await _repositoryAsync.SaveChangesAsync();
        }

        public async Task<IEnumerable<BreadRollModel>> ReadBreadRoll()
        {
            return await _repositoryAsync.GetAllAsync();
        }

        public async Task<BreadRollModel> ReadBreadRolls(int breadRollId)
        {
            return await _repositoryAsync.GetAsync(breadRollId);
        }

        public async Task UpdateBreadRoll(int breadRollId, BreadRollModel newBreadRoll)
        {
            var breadRoll = await _repositoryAsync.GetAsync(breadRollId);
            breadRoll.Name = newBreadRoll.Name;
            breadRoll.ImgUrl = newBreadRoll.ImgUrl;
            breadRoll.UserBreadRolls = newBreadRoll.UserBreadRolls;
            await _repositoryAsync.SaveChangesAsync();
        }
    }
}
