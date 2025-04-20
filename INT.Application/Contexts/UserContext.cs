using static INT.Utility.Enums;

namespace INT.Application.Contexts
{
    public class UserContext
    {
        public long UserId { get; set; } = 1;
        public required string Email { get; set; }
        public Language Language { get; set; }
        public int RoleId { get; set; } = 1;
        public required string UserName { get; set; }
    }
}
