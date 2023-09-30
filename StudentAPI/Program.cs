using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using StudentAPI.DataAccess;
using Microsoft.Extensions.DependencyInjection; 


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Adding dependency for DBContext
builder.Services.AddDbContext<StudentDataContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("CS"));
});

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

static void ConfigureServices(IServiceCollection services)
    {
        // Your service configurations go here
        services.AddLogging(builder => builder.AddConsole());
        
        // Other service configurations...
    }