using INT.Domain.Domain.Core;
using INT.Domain.Domain.Core.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace INT.Domain.Model
{

    [Table("User")]
    public class User : BaseEntity<long>, IAuditableEntity, ISoftDeleteEntity
    {
        [Required]
        [Column("Name")]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [Column("NameHi")]
        [MaxLength(100)]
        public required string NameHi { get; set; }

        [Required]
        [Column("UserName")]
        [MaxLength(100)]
        public required string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
