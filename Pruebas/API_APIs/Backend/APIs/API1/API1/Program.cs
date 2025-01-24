using API1.BLL;
using API1.Dapper;
using API1.IBLL;
using API1.IDapper;
using API1.IServicios;
using API1.Servicios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDapperContext, DapperContext>();
builder.Services.AddSingleton<IUsuarioServicios, UsuarioServicios>();
builder.Services.AddSingleton<IUsuarioBLL, UsuarioBLL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
