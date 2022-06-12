using ClinicaFisioterapia.Context;
using ClinicaFisioterapia.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
			});

			services.AddScoped<IFuncionarioService, FuncionariosService>();

			//services.AddCors();
			services.AddCors(options => {
				options.AddPolicy("CORSPolicy", builder => {
					builder
					.AllowAnyMethod()
					.AllowAnyHeader()
					.WithOrigins("http://localhost:3000/", "https://appname.azurestaticapps.net");

				});

			});
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

			app.UseAuthorization();

			app.UseEndpoints(endpoints => {
				endpoints.MapControllers();
			});

			//app.UseCors(options => {
			//	options.AllowAnyOrigin();
			//	options.AllowAnyMethod();
			//	options.AllowAnyHeader();

			//});

			app.UseCors("CORSPolicy");
			//app.UseCors(option => option.WithOrigins("http://localhost:3000/"));
			//app.UseCors(option => option.WithHeaders("accept", "content-type", "origin"));
			//app.UseCors(option => option.WithMethods("GET","POST"));

		}
	}
}
