using System;
using System.Collections.Generic;

namespace spm_api.Entity
{
    public class Group
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public bool EnabledEmail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ParentGroupId { get; set; }
        public Group ParentGroup { get; set; }
        public ICollection<Group> ChildGroups { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
