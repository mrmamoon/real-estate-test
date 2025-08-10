using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RealEstate.API.Helpers;
using RealEstate.Infrastructure.Data;
using System.Text;
using RealEstate.Core.Interfaces;
using RealEstate.Infrastructure.Repositories;
using RealEstate.Infrastructure.Services;
using RealEstate.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDbContext<RealEstateContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add JWT Authentication
var key = Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

// Register UserAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserAccessor, UserAccessor>();
builder.Services.AddScoped<IPropertyRepository, PropertyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapPost("/api/seed", async (RealEstateContext context) =>
{
    if (!context.Properties.Any())
    {
        context.Properties.AddRange(
            new Property { 
                Title = "Modern Apartment", 
                Address = "123 Main St", 
                Price = 250000, 
                Bedrooms = 2, 
                Bathrooms = 2,
                Description = "Lorem ipsum" 
                },
            new Property { 
                Title = "Suburban House", 
                Address = "456 Oak Ave", 
                Price = 450000, 
                Bedrooms = 4, 
                Bathrooms = 3,
                Description = "Lorem ipsum" 
                }
        );
    }
    
    await context.SaveChangesAsync();
    return Results.Ok("Database seeded");
});

app.Run();