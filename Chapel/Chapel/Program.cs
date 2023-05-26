using Chapel;
using Microsoft.EntityFrameworkCore;
using Tower;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("Main");
builder.Services.AddDbContext<ChapelContext>(
    (serviceProvider,options) => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)),
    ServiceLifetime.Singleton) ;

var app = builder.Build();

Console.WriteLine(HelloEnum.Ending);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
