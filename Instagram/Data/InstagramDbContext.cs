namespace Instagram.Data
{
    using Instagram.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;


    public class InstagramDbContext : IdentityDbContext<User>
    {
        public InstagramDbContext(DbContextOptions<InstagramDbContext> options)
            : base(options)
        {
        }
    }
}