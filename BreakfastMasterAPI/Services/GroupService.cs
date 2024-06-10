using BreakfastMasterAPI.Models;
using BreakfastMasterAPI.Repositories;

namespace BreakfastMasterAPI.Services
{
    public class GroupService : IGroupService
    {
        private readonly IRepositoryAsync<GroupModel> _repositoryAsync;
        public GroupService(IRepositoryAsync<GroupModel> repositoryAsync)
        {
            _repositoryAsync = repositoryAsync;
        }

        public async Task CreateGroup(GroupModel group)
        {
            await _repositoryAsync.AddAsync(group);
            await _repositoryAsync.SaveChangesAsync();
        }

        public async Task DeleteGroup(int groupId)
        {
            var group = await _repositoryAsync.GetAsync(groupId);
            _repositoryAsync.Remove(group);
            await _repositoryAsync.SaveChangesAsync();
        }

        public async Task<GroupModel> ReadGroup(int groupId)
        {
            return await _repositoryAsync.GetAsync(groupId);
        }

        public async Task<IEnumerable<GroupModel>> ReadGroups()
        {
            return await _repositoryAsync.GetAllAsync();
        }

        public async Task UpdateGroup(int groupId, GroupModel newGroup)
        {
            var group = await _repositoryAsync.GetAsync(groupId);
            // update
            await _repositoryAsync.SaveChangesAsync();
        }
    }
}
