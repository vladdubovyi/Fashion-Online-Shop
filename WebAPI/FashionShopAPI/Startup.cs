using AutoMapper;
using Context;
using MapperProfiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Repositories;
using Repositories.Abstract;
using Repositories.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashionShopAPI
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

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "FashionShopAPI", Version = "v1" });
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = "JWT Auth header using bearer scheme. (Example: Bearer {token})",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
						{
							Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
							Scheme = "oauth2",
							Name = "Authorization",
							In = ParameterLocation.Header,
						},
						new List<string>()
					}
				});
			});

			// DB Configurations
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(
					Configuration.GetConnectionString("ServerConnection"),
					optionsBuilder => optionsBuilder.MigrationsAssembly("FashionShopAPI")));

			services.AddTransient<DbContext, AppDbContext>();

			// Repository Configurations
			services.AddTransient<ICategoryRepository, CategoryRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IPurchaseRepository, PurchaseRepository>();
			services.AddTransient<ITagRepository, TagRepository>();
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IPurchaseProductRepository, PurchaseProductRepository>();
			services.AddTransient<IAuthRepository, AuthRepository>();

			// AutoMapper Configurations
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new CategoryMapperProfile());
				mc.AddProfile(new TagMapperProfile());
				mc.AddProfile(new UserMapperProfile());
			});
			IMapper mapper = mapperConfig.CreateMapper();
			services.AddSingleton(mapper);

			// JWT Configuration
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				var key = Encoding.ASCII.GetBytes(Configuration["JwtSettings:Secret"]);

				options.SaveToken = true;
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					RequireExpirationTime = false
				};
			});

			services.Configure<JwtConfig>(Configuration.GetSection("JwtSettings"));

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FashionShopAPI v1"));
			}

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthentication();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
