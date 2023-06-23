using Domain.Models;

namespace Domain.Interfaces
{
	public interface IStockRepo
	{
		List<Stock> GetAllStocks();
		Stock UpdateStockPrice(int id, decimal price);
	}
}

