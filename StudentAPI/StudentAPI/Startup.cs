using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentAPI.AppService;
using StudentAPI.AppService.Contracts;
using StudentAPI.AppService.Implementation;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.QueryObject;
using StudentAPI.Persistance;
using StudentAPI.Persistance.Repository;

namespace StudentAPI
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
            //Dependency Injection
            //Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IEtudiantRepository, EtudientRepository>();
            services.AddScoped<IGenericRepository<Etudiant>, EtudientRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();



            //AppServices
            services.AddTransient(typeof(IGenericAppService<,,,>), typeof(GenericAppService<,,,>));

            services.AddTransient<IGenericAppService<Etudiant, GetEtudiantResource, SetEtudiantResource, RequestQuery>, EtudiantAppService>();
            services.AddTransient<IEtudiantAppService, EtudiantAppService>();



            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
