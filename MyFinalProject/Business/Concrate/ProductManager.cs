using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cachings;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrate;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrate
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }


        [SecuredOperation("product.add,admin:")]
        [ValidationAspect(typeof(ProductValidator))]
        //örneğin yeni ürün eklenince cacheyi boz
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {

            var result = BusinessRules.Run(
                     CheckIfNameExists(product.ProductName),
                     CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                     CheckIfCategoryLimitExceded()
                     );
            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProgramAdded);
        }

        [CacheAspect]          
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 19)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintanceTime);
            }

            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }


        [ValidationAspect(typeof(ProductValidator))]
        //[CacheRemoveAspect("Get")]//bellekteki içerisinde get olan tüm keyleri iptal et
        [CacheRemoveAspect("IProductService.Get")]//bellekteki içerisinde Iproductservice içindeki get olan tüm keyleri iptal et
        public IResult Update(Product product)
        {
            var result = _productDal.GetAll(p => p.CategoryId == product.CategoryId).Count;
            if (result >= 10)
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProgramAdded);
            }
            return new ErrorResult();

        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            //select count(*) from categories where categoryId = 1 
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfNameExists(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any(); ;
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();

        }
        public IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExeded);
            }
            return new SuccessResult();
        }
    }
}
