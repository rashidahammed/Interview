using System.ComponentModel.DataAnnotations;

namespace INT.Application.Model.Requests
{
    public class LoginReqVm
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        public required string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        public required string Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
