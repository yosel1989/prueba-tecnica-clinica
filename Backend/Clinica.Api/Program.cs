
using Clinica.Api.Transients;
using Clinica.Entity.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


//transient
Transient.AddConfigurations(builder.Services);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// context
builder.Services.AddDbContext<ApplicationDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("Conexion")));

// cors
builder.Services.AddCors(options => options
                    .AddPolicy("AllowAll", p => p.SetIsOriginAllowed(isOriginAllowed: _ => true)
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials()));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
