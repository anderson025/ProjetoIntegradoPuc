using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFisioterapia {
	public class Startup {
		public Startup(IConfiguration configuration) {
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services) {

			services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
			services.AddControllers();

			services.AddSwaggerGen(c => {
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClinicaFisioterapia", Version = "v1" });

				//Habilitar autorização usando Swagger JWT

				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
					Name = "Authorization",
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer",
					BearerFormat = "JWT",
					In = ParameterLocation.Header,
					Description = "JWT Authorization"
				});

				c.AddSecurityRequirement(new OpenApiSecurityRequirement{
					{
						new OpenApiSecurityScheme {
							Reference = new OpenApiReference {
								Type = ReferenceType.SecurityScheme,
								Id = "Bearer"
							}
						},
						new string[] { }
					}
				});

			});

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(options => {
					options.TokenValidationParameters = new TokenValidationParameters {
						ValidateIssuer = true,
						ValidateAudience = true,
						ValidateLifetime = true,
						ValidateIssuerSigningKey = true,
						ValidIssuer = Configuration["Jwt:Issuer"],
						ValidAudience = Configuration["Jwt:Audience"],
						IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
					};
				});


			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddScoped<IFuncionarioService, FuncionariosService>();
			services.AddScoped<IPacienteService, PacienteService>();
			services.AddScoped<IAgendamentoService, AgendamentoService>();
			services.AddScoped<IAvaliacaoService, AvaliacaoService>();
			services.AddScoped<IMedicoService, MedicoService>();
			services.AddScoped<ISessaoService, SessaoService>();
			services.AddScoped<IEvolucaoService, EvolucaoService>();
			services.AddScoped<IAuthenticate, AuthenticateService>();


			services.AddCors();
			
		}
		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
			if (env.IsDevelopment()) {
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClinicaFisioterapia v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseCors(options => {
				options.AllowAnyOrigin();
				options.AllowAnyMethod();
				options.AllowAnyHeader();

			});

			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			
		}
	}
}
