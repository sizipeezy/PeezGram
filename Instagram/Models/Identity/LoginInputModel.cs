namespace Instagram.Models.Identity
{
    using System.ComponentModel.DataAnnotations;


    public class LoginInputModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
