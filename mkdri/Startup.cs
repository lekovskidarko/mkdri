using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MKDRI.Models;
using MKDRI.Repositories.Context;
using MKDRI.Repositories.UnitOfWork;
using MKDRI.Services;
using MKDRI.Services.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace MKDRI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFrameworkNpgsql().AddDbContext<MKDRIContext>();
            services.AddCors(options =>
            {
                options.AddPolicy("_myAllowSpecificOrigins", builder =>
                {
                    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MKDRI API", Version = "v0.1" });
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                          .AddJwtBearer(cfg =>
                          {
                              cfg.RequireHttpsMetadata = false;
                              cfg.SaveToken = true;
                              cfg.IncludeErrorDetails = true;
                              cfg.TokenValidationParameters = new TokenValidationParameters()
                              {
                                  ValidIssuer = Configuration.GetSection("TokenIssuer").Value,
                                  ValidAudience = Configuration.GetSection("TokenIssuer").Value,
                                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("SecretKey").Value))
                              };

                          });
            services.AddScoped<UnitOfWork>();
            services.AddScoped<IMKDRIContext, MKDRIContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, userService>();
            services.AddScoped<ILaboratoryService, LaboratoryService>();
            services.AddScoped<IOrganisationService, OrganisationService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MKDRI API V0.1");
            });

            app.UseAuthentication();

            app.UseCors("_myAllowSpecificOrigins");
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
