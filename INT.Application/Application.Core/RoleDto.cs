namespace INT.Application.Application.Core
{
    public class RoleDto
    {
        public string Name { get; set; }
        public string NameHi { get; set; }
        public string Description { get; set; }
        public string DescriptionHi { get; set; }
    }

    public class UpdateRoleDto: RoleDto
    {
        public int Id { get; set; }
    }

    public class ViewRoleDto : UpdateRoleDto
    {
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
