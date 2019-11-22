using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
/*Esto es para hacer serializaciones de json o la deserializaciones de json*/
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;// para personalizar tablas de enrutamiento
using Contoso.DAL.EF;
using Contoso.DAL.Repos;
using Contoso.DAL.Repos.Interfaces;

namespace Contoso.Service
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
            // services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvcCore().AddJsonFormatters(j =>
            {
                //Es un formato de cadena en donde pone la primera letra en mayuscula
                // y la siguiente en minuscula
                j.ContractResolver = new CamelCasePropertyNamesContractResolver();
                //Pone el Json muy bonito estructurado
                j.Formatting = Formatting.Indented;
            });
            /*Utilizando Cors*/
            services.AddCors(options =>
            {
                /*Esto para que permita origen cualquier origen si el servicio es publico por ejemplo*/
                options.AddPolicy("AllowAll", builder =>
                {
                 builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
                });
            });
            services.AddDbContext<ContosoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Contoso")));
            //Agregando Inyeccion de dependencia,cuando manden a llamar interfaz IreportStudent instancias ReportStudent
            services.AddScoped<IReportStudent, ReportStudent>();
            services.AddScoped<IRepoCourse, RepoCourse>();
            services.AddScoped<IRepoEnrollment, RepoEnrollment>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*IAplication builder se encarga de agregar los middleware al path*/
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            /*Agregando Middleware*/
            app.UseCors("AllowAll");

            app.UseMvc();
        }
    }
}
