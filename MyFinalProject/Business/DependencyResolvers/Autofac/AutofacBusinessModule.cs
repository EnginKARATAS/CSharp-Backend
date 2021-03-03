using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.CCS;
using Business.Concrate;
using Castle.DynamicProxy;
using Core.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrate;
using DataAccess.Concrate.EntityFramework;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Utilities.Interceptors.MethodInterception;

namespace Business.DependencyResolvers.Autofac
{
    //module keyword, concern for this project. its not going to core project
    //AutofacBusinessModule a class for IoC config. like builtin IoC func in startup.cs 
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //single instance, holds just one referance. There, we are working with referance typees. so single instance gives one referance to all clients
            //"reflections"********* sistem çalışma zamanında  aşağıdakiler newlenir. reflections unutma
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

      


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

           // builder.RegisterType<HttpContextAccessor>().As(IHttpContextAccessor;

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
