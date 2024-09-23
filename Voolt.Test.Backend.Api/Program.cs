using Voolt.Test.Data;
using Voolt.Test.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AdContext>();
builder.Services.AddScoped<IAdRepository, AdRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();