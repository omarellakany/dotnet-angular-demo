using Domain.Models;

namespace Domain.Interfaces
{
	public interface IOrderRepo
	{
		List<Order> GetAllOrders();
		Order CreateOrder(Order order);
	}
}

