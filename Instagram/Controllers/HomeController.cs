namespace Instagram.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : ApiController
    {
        public ActionResult Get()
        {
            return this.Ok("it works");
        }
    }
}