using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinimalAPI.Data;
using System.Text.Json;

namespace MinimumApi.Test;

public class CustomWebApplicationFactory<Program> : WebApplicationFactory<Program> where Program : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.UseEnvironment("Testing");

        builder.ConfigureServices(services =>
        {
            services.AddDbContext<MinimalAPIDbContext>(options =>
            {
                options.UseInMemoryDatabase($"TestDb"); // Use a fixed database name
            });
        });

        return base.CreateHost(builder);
    }
}


public class MinimalApiTest : IClassFixture<CustomWebApplicationFactory<Program>>, IDisposable
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory<Program> _factory;
    public MinimalApiTest(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MinimalAPIDbContext>();
        context.Database.EnsureCreated();
        context.Greetings.Add(new Greeting { Id = 2, Message = "Test Greeting" });
        context.SaveChanges();
    }


    [Fact]
    public async Task TestMeGet_GiveId_IdIsInresponse()
    {
        const int id = 2;
        var result = await _client.GetAsync($"/TestMe?id={id}");
        result.EnsureSuccessStatusCode();
        var content = await result.Content.ReadAsStringAsync();
        var json = JsonDocument.Parse(content);
        var idResult = json.RootElement.GetProperty("id").GetInt32();
        Assert.Equal(id, idResult);
    }

    public void Dispose()
    {
        using var scope = _factory.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<MinimalAPIDbContext>();
        context.Database.EnsureDeleted();
    }
}
