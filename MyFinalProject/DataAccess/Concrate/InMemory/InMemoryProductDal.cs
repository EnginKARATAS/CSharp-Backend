using DataAccess.Abstract;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrate.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal(IProductDal productDal)
        {
            _products = new List<Product> {
                new Product{ProductId = 1 , CategoryId=1,ProductName="Bardak",UnitPrice = 15, UnitInStock=15 } ,
                new Product{ProductId = 2 , CategoryId=1,ProductName="Kamera",UnitPrice = 500, UnitInStock=3 },
                new Product{ProductId = 3 , CategoryId=2,ProductName="Telefon",UnitPrice = 1500, UnitInStock=2 } ,
                new Product{ProductId = 4 , CategoryId=2,ProductName="Klavye",UnitPrice = 150, UnitInStock=65 }  ,
                new Product{ProductId = 5 , CategoryId=2,ProductName="Fare",UnitPrice = 85, UnitInStock=1 }
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            Product productToDelete = null;
            productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //bir tane arar(firs=firstordefault=singleordefault)

            //linqsuz: git silinecek itemi bul sonra silinecek itemin adresini gönderki silsin 
            //foreach (var item in _products)
            //{
            //    if (product.ProductId == item.ProductId)
            //    {
            //        productToDelete = item;
            //    }
            //}
            //_products.Remove(productToDelete);


        }

        public List<Product> GetAll()
        {
            return _products;
        }
        public void Update(Product product)
        {
            //göndeilen ürün idsine sahip ürün idsine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //bir tane arar(firs=firstordefault=singleordefault)
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;

        }
        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList() ;
        }
    }
}
