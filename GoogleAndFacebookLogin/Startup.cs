using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using GoogleAndFacebookLogin.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoogleAndFacebookLogin
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            /*
             Reference: https://www.youtube.com/watch?v=YSKqZcS6PLg 
             
             - na pasta do projeto
             cmd: dotnet watch run 

             Google and Facebook:
             Informações foram armazenadas no user-secrets através dos comandos abaixo (Package Manager Console):
             
            1) dotnet user-secrets init --project GoogleAndFacebookLogin
            2) dotnet user-secrets set "App:GoogleClientId" "Valor do Google Client Id" --project GoogleAndFacebookLogin
            3) dotnet user-secrets set "App:GoogleClientSecret" "Valor do Google Client Secret" --project GoogleAndFacebookLogin
            4) dotnet user-secrets set "App:FacebookClientId" "Valor do Facebook Client Id" --project GoogleAndFacebookLogin
            5) dotnet user-secrets set "App:FacebookClientSecret" "Valor do Facebook Client Secret" --project GoogleAndFacebookLogin
            6) dotnet user-secrets list --project GoogleAndFacebookLogin
            */

            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["App:GoogleClientId"];
                    options.ClientSecret = Configuration["App:GoogleClientSecret"];
                })
                .AddFacebook(options =>
                {
                    options.ClientId = Configuration["App:FacebookClientId"];
                    options.ClientSecret = Configuration["App:FacebookClientSecret"];
                });


            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
