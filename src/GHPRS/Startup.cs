using System;
using System.Text;
using GHPRS.Core.Entities;
using GHPRS.Core.Interfaces;
using GHPRS.Core.Services;
using GHPRS.Core.UnitOfWork;
using GHPRS.EmailService;
using GHPRS.Persistence;
using GHPRS.Persistence.Repositories;
using GHPRS.Persistence.UnitOfWork;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.OpenApi.Models;

namespace GHPRS
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        private static string[] _allowedOrigins;
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            // add in-memory cache
            services.AddMemoryCache();

            _allowedOrigins = Configuration.GetSection("AllowedOrigins").Get<string[]>();
            // configure CORS
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("*")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            //configure EF Core Postgres SQL
            services.AddDbContext<GhprsContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            // For Identity  
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<GhprsContext>()
                .AddDefaultTokenProviders();

            // Adding Authentication  
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                })

                // Adding Jwt Bearer  
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:ValidAudience"],
                        ValidIssuer = Configuration["JWT:ValidIssuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                    };
                });

            // Add Hangfire services.
            // services.AddHangfire(config =>
            //     config.UsePostgreSqlStorage(Configuration.GetConnectionString("defaultConnection")));
            services.AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UsePostgreSqlStorage(Configuration.GetConnectionString("defaultConnection"), new PostgreSqlStorageOptions
                {
                    QueuePollInterval = TimeSpan.FromSeconds(5.0),
                }));

            // Add the processing server as IHostedService
            services.AddHangfireServer();

            services.AddControllers();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddTransient<ITemplateRepository, TemplateRepository>();
            services.AddTransient<ITemplateService, TemplateService>();
            services.AddTransient<IUploadRepository, UploadRepository>();
            services.AddScoped<IFileUploadRepository, FileUploadRepository>();
            services.AddScoped<IMerDataRepository, MerDataRepository>();
            services.AddScoped<IFacilityDataRepository, FacilityDataRepository>();
            services.AddScoped<ICommunityDataRepository, CommunityDataRepository>();
            services.AddScoped<IUploadService, UploadService>();
            services.AddScoped<ILinkRepository, LinkRepository>();
            services.AddScoped<IExcelService, ExcelService>();
            services.AddTransient<IWorkSheetRepository, WorkSheetRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IColumnRepository, ColumnRepository>();
            services.AddScoped<IMetabaseService, MetabaseService>();
            services.AddScoped<IDataUnitOfWork, DataUnitOfWork>();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            );

            var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "wwwroot";
            });
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "Api", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api v1"));
            }
            else
            {
                app.UseForwardedHeaders();
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "wwwroot";
            });
            var options = new BackgroundJobServerOptions
            {
                WorkerCount=3    //Hangfire's default worker count is 20, which opens 20 connections simultaneously.
                // For this we are overriding the default value.
            };
            app.UseHangfireServer(options);
            app.UseHangfireDashboard();
            loggerFactory.AddFile("Logs/GHPRS-{Date}.txt");
        }
    }
}