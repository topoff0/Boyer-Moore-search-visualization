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

// === Configure CORS === 
const string policyOrigins = "_viteOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyOrigins,
        policy =>
        {
            policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

var app = builder.Build();

app.UseCustomSwagger(app.Environment);

app.UseCors(policyOrigins);

app.MapControllers();

app.Run();
