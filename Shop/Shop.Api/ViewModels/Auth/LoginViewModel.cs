using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="شماره تلفن باید وارد شود")]
        [MaxLength(11)]
        [MinLength(11)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمز کاربری باید وارد شود")]
        public string Password { get; set; }
    }
}
