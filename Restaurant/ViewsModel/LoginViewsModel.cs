using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewsModel
{
    public class LoginViewsModel
    {

        [Required(ErrorMessage = "*Zorunlu Alan")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "*Zorunlu Alan")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        public bool RememberMe { get; set; } = true;
    }
}
