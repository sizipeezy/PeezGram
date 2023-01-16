namespace Instagram.Controllers
{
    using Instagram.Data.Models;
    using Instagram.Models.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;

        public IdentityController(UserManager<User> userManager) =>
                this.userManager = userManager;


        public async Task<IActionResult> Register(RegisterInputModel model)
        {
            var user = new User()
            {
                UserName = model.UserName,
                Email = model.Email,
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return this.Ok();
            }

            return BadRequest(result.Errors);
        }
    }
}
