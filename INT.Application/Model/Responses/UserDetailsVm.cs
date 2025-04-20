namespace INT.Application.Model.Responses
{
    public class UserDetailsVm
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string? NameHi { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string? UserRoles { get; set; }
    }
}
