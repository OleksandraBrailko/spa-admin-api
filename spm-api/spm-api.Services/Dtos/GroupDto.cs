using System;
using System.Collections.Generic;

namespace spm_api.Services.Dtos.Models
{
    public class GroupDto
    {
        public int? Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool EnabledEmail { get; set; }
        public int? ParentGroupId { get; set; }
        public IEnumerable<int> ChildGroupsIds { get; set; }
        public IEnumerable<int> UsersIds { get; set; }
    }
}
