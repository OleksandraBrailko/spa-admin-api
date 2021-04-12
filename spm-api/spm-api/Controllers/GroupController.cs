using Microsoft.AspNetCore.Mvc;
using spm_api.Entity;
using spm_api.Interfaces.Services;
using spm_api.Services.Dtos.Models;
using System.Collections.Generic;

namespace spm_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _GroupService;

        public GroupController(IGroupService GroupService)
        {
            _GroupService = GroupService;
        }

        [HttpGet]
        public IEnumerable<Group> Get()
        {
            return _GroupService.GetGroups();
        }

        [HttpGet]
        [Route("{id}")]
        public Group Get(int id)
        {
            return _GroupService.GetGroup(id);
        }

        [HttpPost]
        public void Create(GroupDto groupDto)
        {
            _GroupService.CreateGroup(groupDto);
        }

        [HttpPut]
        public void Update(GroupDto groupDto)
        {
            _GroupService.UpdateGroup(groupDto);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id)
        {
            _GroupService.DeleteGroup(id);
        }
    }
}
