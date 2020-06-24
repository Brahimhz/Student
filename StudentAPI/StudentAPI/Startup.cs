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
using StudentAPI.Controllers.Resources.Classe.Section;
using StudentAPI.Controllers.Resources.DocumentPartage;
using StudentAPI.Controllers.Resources.Etudiant;
using StudentAPI.Controllers.Resources.Section;
using StudentAPI.Core.IRepository;
using StudentAPI.Core.Models;
using StudentAPI.Core.Settings;
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
            services.AddAutoMapper(typeof(Startup));

            //Settings
            services.Configure<DocumentSettings>(Configuration.GetSection("DocumentSettings"));


            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //Dependency Injection

            //Repository

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IEtudiantRepository, EtudientRepository>();
            services.AddScoped<IGenericRepository<Etudiant>, EtudientRepository>();

            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IGenericRepository<Section>, SectionRepository>();

            services.AddScoped<IDocumentPartageRepository, DocumentPartageRepository>();
            services.AddScoped<IGenericRepository<DocumentPartage>, DocumentPartageRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //AppServices

            services.AddTransient(typeof(IGenericAppService<,,>), typeof(GenericAppService<,,>));

            services.AddTransient<IGenericAppService<Section, GetSectionResource, SetSectionResource>, SectionAppService>();
            services.AddTransient<ISectionAppService, SectionAppService>();

            services.AddTransient<IGenericAppService<Etudiant, GetEtudiantResource, SetEtudiantResource>, EtudiantAppService>();
            services.AddTransient<IEtudiantAppService, EtudiantAppService>();

            services.AddTransient<IGenericAppService<DocumentPartage, GetDocumentPartageResource, SetDocumentPartageResource>, DocumentPartageAppService>();
            services.AddTransient<IDocumentPartageAppService, DocumentPartageAppService>();

            services.AddTransient<IDocumentFileAppService, DocumentFileAppService>();

            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
