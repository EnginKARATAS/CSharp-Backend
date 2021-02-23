using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min,decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IDataResult<Product> GetById(int id);  
        IResult Add(Product product);
    }
}
