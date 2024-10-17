using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

using BibliotecaWebAPI.Repositorio;
using BibliotecaAPI.ORM;
using BibliotecaAPI.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Adicione o contexto do banco de dados
builder.Services.AddDbContext<BdBibliotecaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicione os repositórios
builder.Services.AddScoped<FuncionarioRepositorio>();
builder.Services.AddScoped<MembroRepositorio>();
builder.Services.AddScoped<CategoriaRepositorio>();
builder.Services.AddScoped<LivroRepositorio>();
builder.Services.AddScoped<EmprestimoRepositorio>();
builder.Services.AddScoped<ReservaRepositorio>();
builder.Services.AddScoped<UsuarioRepositorio>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjetoWebAPI", Version = "v1" });
});

// Remover a configuração de autenticação JWT
// var key = "A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P6"; // 32 caracteres para 256 bits
// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateLifetime = true,
//         ValidateIssuerSigningKey = true,
//         ValidIssuer = "http://localhost:7025", // O emissor deve corresponder ao que você definiu no token
//         ValidAudience = "http://localhost:7025", // A audiência deve corresponder ao que você definiu no token
//         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)) // Usando a chave
//     };
// });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ATMWebAPI v1"));
}

app.UseHttpsRedirection();

// Remover a chamada para UseAuthorization
// app.UseAuthorization();

app.MapControllers();

app.Run();
