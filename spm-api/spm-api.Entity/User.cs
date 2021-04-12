using System.Collections.Generic;

namespace spm_api.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAmin { get; set; }
        public ICollection<Group> Groups { get; set; }
    }
}
