using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrate.InMemory;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal inMemoryProductDal)
        {
            _productDal = inMemoryProductDal;
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //if yetkisi var mı ?
            return _productDal.GetAll();
        }
    }
}
