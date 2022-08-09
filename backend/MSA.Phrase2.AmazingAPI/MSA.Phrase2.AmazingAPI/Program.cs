using Microsoft.OpenApi.Models;
using MSA.Phrase2.AmazingAPI.Data;
using MSA.Phrase2.AmazingAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Pet API",
        Description = "An ASP.NET Core Web API for managing pets",
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

// add two http clients
builder.Services.AddHttpClient("CatImages", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://api.thecatapi.com");

});

builder.Services.AddHttpClient("DogImages", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://dog.ceo");
});



//Register the PetContext with ASP.NET core's dependency injection
builder.Services.AddSqlite<PetContext>("Data Source=Pets.db");
builder.Services.AddScoped<PetServiceInterface,PetServiceDb>();
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
