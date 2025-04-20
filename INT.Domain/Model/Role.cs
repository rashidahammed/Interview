using INT.Domain.Domain.Core;
using INT.Domain.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INT.Domain.Model
{
    [Table("Role")]
    public class Role : BaseEntity<int>, IAuditableEntity, ISoftDeleteEntity
    {

        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        [Column("NameHi")]
        [MaxLength(50)]
        public required string NameHi { get; set; }

        [Required]
        [Column("Description")]
        [MaxLength(255)]
        public required string Description { get; set; }

        [Required]
        [Column("DescriptionHi")]
        [MaxLength(255)]
        public required string DescriptionHi { get; set; }

        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public long? LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
