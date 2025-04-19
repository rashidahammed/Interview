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
        public string Name { get; set; }

        [Required]
        [Column("NameHi")]
        [MaxLength(100)]
        public string NameHi { get; set; }

        [Required]
        [EmailAddress]
        [Column("Email")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
