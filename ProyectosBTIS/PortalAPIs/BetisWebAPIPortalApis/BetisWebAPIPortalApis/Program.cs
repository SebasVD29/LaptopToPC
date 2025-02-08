
using BetisWebAPIPortalApis.Helpers;
using BetisWebAPIPortalApis.Services;
using BtisEntities.EUsers;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration; 
var environment = builder.Environment;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<EITokenSettings>(configuration.GetSection("ApplicationSettings"));
builder.Services.AddScoped<IUserService, UserService>();

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

app.UseWebSockets(); 
//app.UseSocket(); 
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
// Configuración adicional DBConnection.SetDBConfiguration(configuration); SettingsO365.token(configuration);

app.Run();
