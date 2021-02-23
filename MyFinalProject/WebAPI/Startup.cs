using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //built-in(kendi içinde var olan) api control. Javada bin klasörünün içinden yapılıyor
        public void ConfigureServices(IServiceCollection services)
        {
            //Autofac, Ninject, CastleWindsor, StructureMap, Lightnject, DryInject -->IoC Container
            services.AddControllers();
            services.AddSingleton<IProductService, ProductManager>();//singelton, tüm bellekte bir tane product manager oluşturur. gelen tüm clientlere aynı newlenmiş classı verir.. singelton içerisinde bir tane newleyip verdiğinden, data tutmada singelton kullanılmamalı. çünkü bir tane newliyoruz. örneğin bir tane e ticaret sepeti olur tutarsan. 
            services.AddSingleton<IProductDal, EfProductDal>(); ;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
