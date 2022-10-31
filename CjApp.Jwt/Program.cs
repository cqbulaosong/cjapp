using CjApp.IRepository;
using CjApp.IService;
using CjApp.Repository;
using CjApp.Service;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("MySqlConn");
builder.Services.AddSqlSugar(new IocConfig
{
    ConnectionString = connectionString,
    DbType = IocDbType.MySql,
    IsAutoCloseConnection = true //自动释放
});
// 注入服务
builder.Services.AddScoped<ISystemUserRepository, SystemUserRepository>();
builder.Services.AddScoped<ISystemUserService, SystemUserService>();
builder.WebHost.UseUrls("http://*:7776");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()||app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();