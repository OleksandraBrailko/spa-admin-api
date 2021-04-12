using spm_api.Entity;
using spm_api.Services.Dtos.Models;
using System.Collections.Generic;

namespace spm_api.Interfaces.Services
{
    public interface IGroupService
    {
        void CreateGroup(GroupDto group);
        void DeleteGroup(int id);
        Group GetGroup(int id);
        IEnumerable<Group> GetGroups();
        void UpdateGroup(GroupDto groupDto);
    }
}
