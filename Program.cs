using DailyAPP.WebAPI.AutoMappers;
using DailyAPP.WebAPI.DataModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(cfg=>
{
    cfg.AddProfile<AutoMapperSettings>();
});
builder.Services.AddSwaggerGen(m =>
{
    string path = AppContext.BaseDirectory + "DailyAPP.WebAPI.xml";
    m.IncludeXmlComments(path);
});
builder.Services.AddDbContext<DailyDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("SqliteConnection");
    options.UseSqlite(connectionString);
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.LogTo(Console.WriteLine, LogLevel.Information);
    }
});
string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "dailyAppDB.db");
Console.WriteLine("当前数据库路径：" + dbPath); // 运行后查看控制台输出
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
