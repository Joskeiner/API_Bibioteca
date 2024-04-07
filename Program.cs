using APIBiblioteca.DAL.DataContext;
using Microsoft.EntityFrameworkCore;
using APIBiblioteca.DAL.Implement;
using APIBiblioteca.DAL.Interface;
using APIBiblioteca.DTO;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("connectSql")));
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddAutoMapper(typeof(AuthorCreateDTO));


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
