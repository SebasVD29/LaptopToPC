
using BetisWebAPIPortalApis.BLL;
using BetisWebAPIPortalApis.Helpers;
using BetisWebAPIPortalApis.Services;
using BtisDataAccess;
using BtisEntities.EUsers;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; 
var environment = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<EITokenSettings>(configuration.GetSection("ApplicationSettings"));
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<UsuarioBLL>();

builder.Services.AddSingleton<IConfiguration>(configuration); 
builder.Services.AddCors(options => options.AddPolicy("AllowWebApp", 
    builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<JwtMiddleware>(); 
app.UseCors("AllowWebApp");

DBConnection.SetDBConfiguration(builder.Configuration);
SettingsO365.token(builder.Configuration);

app.UseWebSockets(); 
//app.UseSocket(); 
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
// Configuración adicional DBConnection.SetDBConfiguration(configuration); SettingsO365.token(configuration);

app.Run();
