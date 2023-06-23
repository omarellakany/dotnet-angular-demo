using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class StockController : ControllerBase
	{
        private readonly IStockRepo _stockRepo;

        public StockController(IStockRepo stockRepo) {
            _stockRepo = stockRepo;
        }

        [HttpGet]
        public ActionResult<List<Stock>> GetAll() {
            var allStocks = _stockRepo.GetAllStocks();
            return CreatedAtAction(nameof(GetAll), allStocks);
        }

        [HttpPut]
        public ActionResult<List<Stock>> UpdateStockPrice(int id, decimal price)
        {
            var stock = _stockRepo.UpdateStockPrice(id, price);
            return CreatedAtAction(nameof(UpdateStockPrice), stock);
        }
    }
}

