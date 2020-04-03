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
    [Route("api/ordermanagement/order/1")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderLogic _logic;

        public OrderController()
        {
            var repo = new EFGenericRepository<OrderPoco>();
            _logic = new OrderLogic(repo);
        }

        [HttpGet]
        [Route("order/{id}")]
        public ActionResult GetApplicantEducation(Guid id)
        {
            OrderPoco poco = _logic.Get(id);
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
        [Route("order")]
        public ActionResult GetAllOrders ()
        {
            var orders = _logic.GetAll();
            if (orders == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(orders);
            }
        }

        [HttpPost]
        [Route("order")]
        public ActionResult PostOrder(
            [FromBody]OrderPoco[] orders)
        {
            _logic.Add(orders);
            return Ok();
        }

        [HttpPut]
        [Route("order")]
        public ActionResult PutOrder(
            [FromBody]OrderPoco[] pocos)
        {
            _logic.Update(pocos);
            return Ok();
        }

        [HttpDelete]
        [Route("order")]
        public ActionResult DeleteOrder(
            [FromBody]OrderPoco[] pocos)
        {
            _logic.Delete(pocos);
            return Ok();
        }


    }
}