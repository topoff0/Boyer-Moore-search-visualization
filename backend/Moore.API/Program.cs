using Moore.API.Extensions;
using Moore.Core.Interfaces;
using Moore.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// === Controllers ===
builder.Services.AddControllers();

// === Swagger ===
builder.Services.AddCustomSwagger();

// === Services ===
builder.Services.AddScoped<IMooreService, MooreService>();

var app = builder.Build();

app.UseCustomSwagger(app.Environment);

app.MapControllers();

app.Run();
