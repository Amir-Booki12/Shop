using System.ComponentModel.DataAnnotations;

namespace Shop.Api.ViewModels.Auth
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "شماره تلفن باید وارد شود")]
        [MaxLength(11,ErrorMessage ="شماره موبایل باید 11 کاراکتر  باشد")]
        [MinLength(11, ErrorMessage = "شماره موبایل باید 11 کاراکتر  باشد")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "رمز کاربری باید وارد شود")]
        public string Password { get; set; }


        [Required(ErrorMessage = "تکرار رمز کاربری باید وارد شود")]
        [Compare("Password",ErrorMessage ="رمزهای عبور کاربر باهم مغایرت دارد")]
        public string ConfirmPassword { get; set; }
    }
}
