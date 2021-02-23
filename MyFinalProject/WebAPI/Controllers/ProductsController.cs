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
        //IoC --Inversion of Control
        IProductService _productService; //buna bağımlıyız artık. Get()`in 2. satırında productmanageri newledik. bundan kaçınmak için zayıf bağımlılık olarak interface üzerinden gittik. fakat interface üzerinden gidip aynı sonucu yazdırmak istediğimizde Unable to resolve hatası aldık. neyi newleyeceğini bilemedi. bu sornunu çzözmek için WebAPI katmanının içerisinde Startup.cs içerisinde IoC yapısını .Net ile gelen temel IoC ayarlarını kullanarak öğreneceğiz.
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet("getall")]
        public IActionResult Get()
        {
            //dependency chain.
            //IProductService productService = new ProductManager(new EfProductDal());
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);//http result code 200 OK işlem oksa datayı ver
                //return Created();//201
            }
            return BadRequest(result);
        }
        [HttpGet("getbyid")]
        public IActionResult Get(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
