using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assembly = typeof(Program).Assembly;
var DBConnectionString = builder.Configuration.GetConnectionString("Database")!;
var RedisConnectionString = builder.Configuration.GetConnectionString("Redis")!;

builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(DBConnectionString);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
//builder.Services.AddScoped<IBasketRepository>(provider => {
//    var basketRepository = provider.GetRequiredService<BasketRepository>();
//    return new CachedBasketRepository(basketRepository, provider.GetRequiredService<IDistributedCache>());
//});

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = RedisConnectionString;
    // options.InstanceName = "Basket";
});

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(DBConnectionString)
    .AddRedis(RedisConnectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapCarter();
app.UseExceptionHandler(opts => { });
app.UseHealthChecks("/health", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();
