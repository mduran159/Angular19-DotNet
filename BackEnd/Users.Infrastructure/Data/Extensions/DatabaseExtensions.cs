using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Users.Infrastructure.Data.Extensions;

namespace Users.Infrastructure.Data.Extensions;
public static class DatabaseExtensions
{
    public static async Task InitializeDatabaseAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

        context.Database.MigrateAsync().GetAwaiter().GetResult();

        await SeedAsync(context);
    }
    
    private static async Task SeedAsync(AppDbContext context)
    {
        await SeedUsersAsync(context);
    }

    private static async Task SeedUsersAsync(AppDbContext context)
    {
        if (!await context.Users.AnyAsync())
        {
            await context.Users.AddRangeAsync(InitialData.Users);
            await context.SaveChangesAsync();
        }
    }
}
