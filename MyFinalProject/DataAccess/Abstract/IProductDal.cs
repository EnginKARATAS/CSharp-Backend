using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IProductDal                                                                                            
    {
        //interface metodları default publicdir ⬇
        List<Product> GetAll(); //anasayfadaki ürünler gibi
        void Add(Product product);
        void Update(Product product);
        void Delete(Product product);
        List<Product> GetAllByCategory(int categoryId); 
    }
}                                   
