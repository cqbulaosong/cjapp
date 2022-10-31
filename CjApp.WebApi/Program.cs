using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CjApp.Enum;
using CjApp.IRepository;
using CjApp.IService;
using CjApp.Repository;
using CjApp.Service;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SqlSugar.IOC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //显示多个文档
    typeof(ApiVersion).GetEnumNames().ToList().ForEach(version =>
    {
        //添加文档介绍
        options.SwaggerDoc(version, new OpenApiInfo
        {
            Title = "CjApp",
            Version = version.ToString(),
            Description = $"陈娟是猪：{version}版本"
        });
    });
    //获取xml文件名称
    var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //包含注释,第二个参数表示是否显示控制器注释
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName), true);

    #region Swagger使用鉴权组件

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Description = "直接在下框中输入Bearer {token}(两者之间是空格)",
        Name = "Authorization",
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });

    #endregion
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetConnectionString("IssuerSigningKey"))),
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetConnectionString("Issuer"),
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetConnectionString("Audience"),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.FromMinutes(30)
        };
    });
builder.Services.AddMemoryCache();
var connectionString = builder.Configuration.GetConnectionString("MySqlConn");
builder.Services.AddSqlSugar(new IocConfig
{
    ConnectionString = connectionString,
    DbType = IocDbType.MySql,
    IsAutoCloseConnection = true //自动释放
});
// 注入服务
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging(cfg => { cfg.AddLog4Net("Config/log4net.config"); });
// builder.WebHost.UseUrls("http://*:9527");//可以覆盖launchSetting中的端口

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => { typeof(ApiVersion).GetEnumNames().ToList().ForEach(version => { options.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{version}版本"); }); });
}

app.UseHttpsRedirection();

//鉴权
app.UseAuthentication();
//授权
app.UseAuthorization();

app.MapControllers();

app.Run();