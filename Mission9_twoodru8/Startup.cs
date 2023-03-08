using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission9_twoodru8.Model;

namespace Mission9_twoodru8
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
			services.AddControllersWithViews();
			services.AddRazorPages();
			services.AddDbContext<BookstoreContext>(options =>
			{
				options.UseSqlite(Configuration["ConnectionStrings:BookStoreDBConn"]);
			}
			);
			//this is decoupling
			services.AddScoped<IBookstoreRepo, EFBookstoreReop>();
			services.AddDistributedMemoryCache();
			services.AddSession();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseSession();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				// these happen in order of how they are, so make sure that this is first
				endpoints.MapControllerRoute("categoryPage",
					"{bookCategory}/Page{pageNum}",
					new { Controller = "Home", action = "Index", pageNum = 1 });
				endpoints.MapControllerRoute(
					name: "Paging",
					pattern: "Page{pageNum}",
					defaults: new { Controller = "Home", action = "Index" }
					);
				endpoints.MapControllerRoute("category",
					"{bookCategory}",
					new { Controller = "Home", action = "Index", pageNum = 1 });
				//default controller route, controller, view, id
				endpoints.MapDefaultControllerRoute();
				endpoints.MapRazorPages();
			});
		}
	}
}
