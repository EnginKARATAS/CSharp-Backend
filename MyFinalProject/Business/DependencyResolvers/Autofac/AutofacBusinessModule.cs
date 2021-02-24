using Autofac;
using Business.Abstract;
using Business.Concrate;
using DataAccess.Abstract;
using DataAccess.Concrate.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    //module keyword, concern for this project. its not going to core project
    //AutofacBusinessModule a class for IoC config. like builtin IoC func in startup.cs 
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //single instance, holds just one referance. There, we are working with referance typees. so single instance gives one referance to all clients
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();
        }
    }
}
