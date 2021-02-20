using Entities.Concrate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrate.EntityFramework
{
    //Context : Db tabloları ile proje classlarını bağlamak
    public class NorthwindContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //key insensetive
            optionsBuilder.UseSqlServer(@"Server=.;Database=Northwind;Trusted_Connection=true");//Trusted_Connection=true = Integrated_Security=true : sql serverde kullanıcı adı şifre girme yerini istemiyoruz anlamına geliyor.domain yönetimi iyi olan sistemlerde trusted connection kullanılır. daha profesyonelddir. ama projeler genellikle kullanıcı adı şifreye sahip olur 
        }
            
        public DbSet<Product> Products { get; set; } //Product class equal to northwinddeki products table
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
