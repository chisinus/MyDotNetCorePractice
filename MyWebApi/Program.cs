using MyWebApi.Models;
using MyWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// MongoDB
builder.Services.Configure<MyMongoDBSettings>(builder.Configuration.GetSection("MyMongoDB"));
builder.Services.AddSingleton<MyMongoDBService>();

builder.Services.AddDbContext<FBContext>(ServiceLifetime.Scoped);
builder.Services.AddScoped<IEFService, EFService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
