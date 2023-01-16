namespace Instagram.Infrastructure
{
    using Instagram.Data;
    using Microsoft.EntityFrameworkCore;


    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<InstagramDbContext>();

            dbContext.Database.Migrate();
        }
    }
}
