using INT.Utility.Resources;
using System.ComponentModel.DataAnnotations;
using static INT.Utility.Enums;

namespace INT.Application.Model.Requests
{
    public class CreateUserVm
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        [Display(Name = "DisplayName", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        [RegularExpression(AllowedCharector.EnglishExpresssion, ErrorMessageResourceName = "English", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        public required string Name { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        [Display(Name = "DisplayNameHindi", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        [RegularExpression(AllowedCharector.HindiExpression, ErrorMessageResourceName = "Hindi", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        public required string NameHi { get; set; }


        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        [Display(Name = "UserName", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        public required string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(AppResource))]
        public required string Email { get; set; }


        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [Display(Name = "Password", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        public required string Password { get; set; }


        [Display(Name = "UserRoles", ResourceType = typeof(INT.Utility.Resources.AppResource))]
        public required List<int> UserRoles { get; set; }
    }

    public class UpdateUserVm : CreateUserVm
    {
        public long Id { get; set; }
    }
}
