using RefitConsole.Services;

using Refit;
using RefitConsole;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddRefitClient<IBuildVersionsApi>()
            .ConfigureHttpClient(c =>
            {
              c.BaseAddress = new Uri("https://localhost:7242/");
              //If you need any headers or authentications added to your requests
              //(it's also possible to add them as attributes to the interface or its methods):
              //c.DefaultRequestHeaders.Add("user-agent", "News-API-csharp/0.1");
              //c.DefaultRequestHeaders.Add("x-api-key", YourApiKey);
            });

builder.Services.AddTransient<Test>();

var host = builder.Build();

await host.StartAsync();

using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
var test = services.GetRequiredService<Test>();
await test.Run();

await host.StopAsync();


//refitter --cancellation-tokens --output ./RefitConsole/Services/IBuildVersionsApi.cs https://localhost:7242/swagger/v1/swagger.json