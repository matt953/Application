using API.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddJsonFile(builder.Environment.ContentRootPath + "/vault/secrets/appsettings.json", optional: false, reloadOnChange: true);
}
else
{
    builder.Configuration.AddJsonFile("/vault/secrets/appsettings.json", optional: false, reloadOnChange: true);
}


Console.WriteLine(builder.Configuration.GetSection("ConnectionStrings")["Database"]);

builder.Services.AddDbContext<DataContext>(opt =>
          opt.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings")["Database"]));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<DataContext>();
    context.Database.EnsureCreated();
}

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
