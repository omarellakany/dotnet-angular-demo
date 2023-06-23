using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepo _orderRepo;

        public OrderController(IOrderRepo orderRepo) {
            _orderRepo = orderRepo;
        }

        [HttpGet]
        public ActionResult<List<Order>> GetAll() {
            var allOrders = _orderRepo.GetAllOrders();
            return CreatedAtAction(nameof(GetAll), allOrders);
        }

        [HttpPost]
        public ActionResult<Order> Create([FromBody] Order order) {
            var createdOrder = _orderRepo.CreateOrder(order);
            return CreatedAtAction(nameof(GetAll), createdOrder.Id, createdOrder);
        }
    }
}

