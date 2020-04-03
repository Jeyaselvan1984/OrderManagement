using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderManagement.BusinessLogicLayer;
using Microsoft.AspNetCore.Http;
using OrderManagement.EntityFrameworkDataAccess;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Pocos;
using CareerCloud.EntityFrameworkDataAccess;

namespace OrderManagement.WebAPI.Controllers
{
    [Route("api/ordermanagement/product/1")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductLogic _logic;

        public ProductController()
        {
            var repo = new EFGenericRepository<ProductPoco>();
            _logic = new ProductLogic(repo);
        }

        [HttpGet]
        [Route("product/{id}")]
        public ActionResult GetProduct(Guid id)
        {
            ProductPoco poco = _logic.Get(id);
            if (poco == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(poco);
            }
        }

        [HttpGet]
        [Route("product")]
        public ActionResult GetAllProducts()
        {
            var products = _logic.GetAll();
            if (products == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(products);
            }
        }

        [HttpPost]
        [Route("product")]
        public ActionResult PostProduct(
            [FromBody]ProductPoco[] products)
        {
            _logic.Add(products);
            return Ok();
        }

        [HttpPut]
        [Route("product")]
        public ActionResult PutProduct(
            [FromBody]ProductPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("product")]
        public ActionResult DeleteProduct(
            [FromBody]ProductPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }


    }
}