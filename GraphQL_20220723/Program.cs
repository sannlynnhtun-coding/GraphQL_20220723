using GraphQL_20220723.EFDbContext;
using GraphQL_20220723.Queries;
using Microsoft.EntityFrameworkCore;

namespace GraphQL_20220723
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //builder.Services.AddSingleton<IAppDbContext, AppDbContext>();
            //builder.Services.AddScoped<IAppDbContext, AppDbContext>();

            builder.Services.AddGraphQLServer().AddQueryType<RegionQuery>();

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.Run();
        }
    }
}