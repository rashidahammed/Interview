using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace INT.WebApi.UI.Model
{
    public class CreateRoleVm
    {
        [Required]
        [Column("Name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Column("NameHi")]
        [MaxLength(50)]
        public string NameHi { get; set; }

        [Required]
        [Column("Description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required]
        [Column("DescriptionHi")]
        [MaxLength(255)]
        public string DescriptionHi { get; set; }
    }
}
