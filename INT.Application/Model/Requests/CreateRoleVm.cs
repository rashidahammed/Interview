using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static INT.Utility.Enums;

namespace INT.Application.Model.Requests
{
    public class CreateRoleVm
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [Column("Name")]
        [MaxLength(50)]
        [Display(Name = "DisplayName", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        [RegularExpression(AllowedCharector.EnglishExpresssion, ErrorMessageResourceName = "English", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [Column("NameHi")]
        [MaxLength(50)]
        [Display(Name = "DisplayNameHindi", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        [RegularExpression(AllowedCharector.HindiExpression, ErrorMessageResourceName = "Hindi", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        public string NameHi { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [Column("Description")]
        [MaxLength(255)]
        [Display(Name = "Description", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        [RegularExpression(AllowedCharector.EnglishExpresssion, ErrorMessageResourceName = "English", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]

        public string Description { get; set; }

        [Required]
        [Column("DescriptionHi")]
        [Display(Name = "DescriptionHi", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        [RegularExpression(AllowedCharector.HindiExpression, ErrorMessageResourceName = "Hindi", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(255)]
        public string DescriptionHi { get; set; }
    }

    public class UpdateRoleVm : CreateRoleVm
    {
        public int Id { get; set; }
    }
}
