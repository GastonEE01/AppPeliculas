using AppPeliculas.Application.Interfaces;
using AppPeliculas.Application.UseCase;
using AppPeliculas.Infrastructure.Data;
using AppPeliculas.Infrastructure.Repositories;
using AppPeliculas.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient<AIService>();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Ingresá: Bearer {tu token}"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
// JWT
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("clave_ultra_super_mega_secreta_2026")
            ),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });
builder.Services.AddAuthorization();

// Inyeccion de interfaz
builder.Services.AddScoped<IMovieIRepository, MovieRepository>();
builder.Services.AddScoped<IFavoriteMovieRepository,FavoriteMovieRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IAIService, AIService>();
builder.Services.AddScoped<IMovieRatingRepository, MovieRatingRepository>();

// Inyeccion de useCase
builder.Services.AddScoped <AddFavoriteMovieUseCase>();
builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<GetMoviesUseCase>();
builder.Services.AddScoped<LoginUseCase>();
builder.Services.AddScoped<GetMovieRecommendationsUseCase>();
builder.Services.AddScoped<RecomenderMoviesUserUseCase>();
builder.Services.AddScoped<GetFavoriteMovieUserUseCase>();
builder.Services.AddScoped<DeleteFavoriteMovieUserUseCase>();
builder.Services.AddScoped<UserAddMovieRatingUseCase>();

// Servicios
builder.Services.AddHttpClient<AIService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
                "http://localhost:5173",                  // Tu React en tu PC
                "https://app-peliculas-three.vercel.app"   // Tu React publicado en Vercel
              )
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var connectionString = Environment.GetEnvironmentVariable("CUSTOM_DB_CONNECTION");

// 2. Si no existe (porque estás en tu PC local), usa el appsettings.json
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}
Console.WriteLine(connectionString);
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

app.UseCors("AllowFrontend");
// Configure the HTTP request pipeline
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    { 
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
      c.RoutePrefix = string.Empty;
    });


// middleware

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
