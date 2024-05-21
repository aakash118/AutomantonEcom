using Discount.gRPC.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.API.Extensions
{
    public static class ExtendMigration
    {
        public static IApplicationBuilder UseMigration(this IApplicationBuilder builder)
        {
            var scope = builder.ApplicationServices.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<DiscountContext>();
            context.Database.MigrateAsync();

            return builder;
        }
    }
}
