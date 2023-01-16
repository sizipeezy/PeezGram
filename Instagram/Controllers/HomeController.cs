namespace Instagram.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    [ApiController]
    [Route("{controller}")]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
        {
            return this.Ok("it works");
        }
    }
}