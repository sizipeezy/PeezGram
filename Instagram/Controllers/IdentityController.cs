namespace Instagram.Controllers
{
    using Instagram.Data.Models;
    using Instagram.Models.Identity;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public class IdentityController : ApiController
    {
        private readonly UserManager<User> userManager;
        private readonly Settings appSettings;

        public IdentityController(UserManager<User> userManager, IOptions<Settings> appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings.Value;
        }

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

        public async Task<ActionResult<string>> Login(LoginInputModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.UserName);
            if(user == null)
            {
                return this.Unauthorized();
            }

            var passwordValidate = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValidate)
            {
                return this.Unauthorized();
            }


            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
