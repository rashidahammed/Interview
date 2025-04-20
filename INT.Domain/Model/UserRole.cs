using INT.Domain.Domain.Core.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace INT.Domain.Model
{
    [Table("UserRole")]
    public class UserRole : BaseEntity<long>, IAuditableEntity, ISoftDeleteEntity
    {
        public long UserId { get; set; }
        public int RoleId { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
