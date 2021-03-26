using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
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
        //Loosely coupled
        //Private IProductService _productService; fieldlerin default u
        //_productService --> naming convention
        //IoC Container --> Inversion of control
        IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
          //ProductManager productService = new ProductManager(new EfProductDal());

            //Dependency chain -- IProductService bir ProductManager'a ihtiyaç duyuyor ,ProductManager da bir EfProductDal'a ihtiyaç duyuyor
            //IProductService productService = new ProductManager(new EfProductDal());
            //Swagger--> API nin ne zaman ne veriyor olduğu ile ilgili dokümantasyon sağlar
            var result = _productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(int Id)
        {
            var result = _productService.GetById(Id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product); //Client'(Angular,React vs..)dan gelen ürünü ekle

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
	

	}
    
}
