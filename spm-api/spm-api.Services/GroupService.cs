using Microsoft.EntityFrameworkCore;
using spm_api.Entity;
using spm_api.Interfaces.Services;
using spm_api.Services.Dtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace spm_api.Services
{
    public class GroupService : IGroupService
    {
        private readonly SpmDbContext _dbContext;

        public GroupService(SpmDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateGroup(GroupDto groupDto)
        {
            var group = GetGroup(groupDto);

            if (groupDto.UsersIds != null)
            {
                var users = _dbContext.Users.Where(item => groupDto.UsersIds.Contains(item.Id)).ToList();

                group.Users = users;
            }

            if (groupDto.ChildGroupsIds != null)
            {
                var childGroups = _dbContext.Groups.Where(item => groupDto.ChildGroupsIds.Contains(item.Id)).ToList();

                group.ChildGroups = childGroups;
            }

            group.CreatedDate = DateTime.UtcNow;

            _dbContext.Groups.Add(group);
            _dbContext.SaveChanges();
        }

        public void DeleteGroup(int id)
        {
            _dbContext.Groups.Remove(new Group { Id = id });
            _dbContext.SaveChanges();
        }

        public Group GetGroup(int id)
        {
            return _dbContext.Groups.Include(item => item.Users).Include(item => item.ChildGroups).FirstOrDefault(item => item.Id == id);
        }

        public IEnumerable<Group> GetGroups()
        {
            return _dbContext.Groups.Include(item => item.Users).Include(item => item.ChildGroups);
        }

        public void UpdateGroup(GroupDto groupDto)
        {
            var group = GetGroup(groupDto.Id.Value);

            group.GroupName = groupDto.GroupName;
            group.Description = groupDto.Description;
            group.Email = groupDto.Email;
            group.EnabledEmail = groupDto.EnabledEmail;
            group.ParentGroupId = groupDto.ParentGroupId;

            if (groupDto.UsersIds != null)
            {
                var users = _dbContext.Users.Where(item => groupDto.UsersIds.Contains(item.Id)).ToList();

                group.Users = users;
            }

            if (groupDto.ChildGroupsIds != null)
            {
                var childGroups = _dbContext.Groups.Where(item => groupDto.ChildGroupsIds.Contains(item.Id)).ToList();

                group.ChildGroups = childGroups;
            }

            _dbContext.Update(group);
            _dbContext.SaveChanges();
        }

        private Group GetGroup(GroupDto groupDto)
        {
            return new Group
            {
                Id = groupDto.Id ?? 0,
                GroupName = groupDto.GroupName,
                Description = groupDto.Description,
                Email = groupDto.Email,
                EnabledEmail = groupDto.EnabledEmail,
                ParentGroupId = groupDto.ParentGroupId
            };
        }
    }
}
