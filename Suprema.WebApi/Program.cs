using Suprema.Repositorio.Interfaces;
using Suprema.Servico.Interfaces;
using Suprema.Servico.Servicos;
using Suprema.Base.Repositorio.Repositorios;
using Suprema.Comum.Infra;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add services to the container.
builder.Services.AddDbContext<ComumBDContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepositorio, UserRepositorio>();



builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//var myProvider = new ApiAuthorizationServerProvider();

//var options = new OAuthAuthorizationServerOptions
//{
//    AllowInsecureHttp = true,
//    TokenEndpointPath = new PathString("/token"),
//    AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
//    Provider = myProvider
//};

//app.UseOAuthAuthorizationServer(options);
//app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();