namespace spm_api.Services.Dtos.Models
{
    public class UserDto : LoginDto
    {
        public int? Id { get; set; }
        public string UserName { get; set; }
        public bool IsAmin { get; set; }
    }
}
