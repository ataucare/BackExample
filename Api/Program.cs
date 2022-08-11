using Api.Core.Configurations;
using Api.Core.Interfaces;
using Api.Extensions;
using Api.Infrastructure.Data;
using Api.Infrastructure.Mappings;
using Api.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using System.Reflection;
using System.Text;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    ConfigurationManager Configuration = builder.Configuration;
    IWebHostEnvironment Environment = builder.Environment;

    // Add services to the container.
    builder.Services.AddDbContext<ApiContext>(options =>
        options
            .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
            //.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), o => o.CommandTimeout(120))
            .UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), o => o.CommandTimeout(120))
            .EnableDetailedErrors(Environment.IsDevelopment())
    );

    builder.Services.Configure<JwtOptions>(Configuration.GetSection("Jwt"));

    builder.Services.AddScoped<IServiceAuth, ServiceAuth>();

    builder.Services.AddAutoMapper(typeof(AutoMapping));

    builder.Services.SetupEmail(Configuration.GetSection("Smtp").Get<SmtpOptions>());

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("MyPolicy", policy =>
        {
            policy
                .AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod();
        });
    });

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "API",
            Description = "API para algun sistema",
            Contact = new OpenApiContact
            {
                Name = "El nombre del departamento",
                Email = "email-del-departamento@gmail.com"
            }
        });

        // using System.Reflection;
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Insert JWT Token with Bearer",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
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
                new string[] { }
            }
        });
    });

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"]))
            };
        });

    //builder.Services.AddMassTransit(config =>
    //{
    //    //config.AddConsumer<PreregistroDiaPatrimonio.Events.PreregistroDiaPatrimonio>();
    //
    //    config.UsingInMemory((context, cfg) =>
    //    {
    //        cfg.ConfigureEndpoints(context);
    //        if (Environment.IsProduction())
    //        {
    //            cfg.UseMessageRetry(r =>
    //            {
    //                r.Interval(3, TimeSpan.FromSeconds(60));
    //                r.Handle<EmailSendedException>();
    //            });
    //        }
    //    });
    //});

    //builder.Services.AddMassTransitHostedService();

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();
    AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // https://www.npgsql.org/doc/types/datetime.html

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseCors("MyPolicy");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}

