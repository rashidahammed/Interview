using System.ComponentModel.DataAnnotations;

namespace INT.WebApi.Model.Requests
{
    public class LoginReqVm
    {
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        public required string UserName { get; set; }

        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(INT.Utility.Resources.AppResource))]
        [MaxLength(100)]
        public required string Password { get; set; }
    }
}
