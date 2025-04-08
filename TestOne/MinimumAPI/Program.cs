using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;

public partial class Program {
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        if (builder.Environment.EnvironmentName != "Testing")
            builder.Services.AddDbContext<MinimalAPIDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        var app = builder.Build();

        app.MapGet("/TestMe", async (int id, MinimalAPIDbContext context) =>
        {
            var greeting = context.Greetings.FirstOrDefault(x => x.Id == id);
            await Task.Delay(1); // Simulate some async work
            return Results.Ok(greeting);
        })
        .WithName("TestMe");

        await app.RunAsync();
    }
}
