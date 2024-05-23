using System.ComponentModel.DataAnnotations;

namespace Restaurant.ViewsModel
{
    public class ResetPasswordViewsModel
    {
        public string Token { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;


        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        //Confirm Parola için onay 

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parola eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;



    }
}
