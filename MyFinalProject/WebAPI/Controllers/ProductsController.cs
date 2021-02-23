using Business.Abstract;
using Business.Concrate;
using Core.Utilities.Results;
using DataAccess.Concrate.EntityFramework;
using Entities.Concrate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {   
        [HttpGet]                                                           
        public List<Product> Get()
        {
            IProductService productService = new ProductManager(new EfProductDal());
            var result = productService.GetAll();
            return result.Data;
        }
    }
}
