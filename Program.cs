global using dotnet_rgb.Models; // the whole app knows this reference
global using dotnet_rgb.Services.CharacterService;  // using the new interface and class for dependency injection
global using dotnet_rgb.Dtos.Character;
global using AutoMapper;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// adding automapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// AddScoped => create a new instance of the requested service for every request
builder.Services.AddScoped<ICharacterService, CharacterService>();

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
