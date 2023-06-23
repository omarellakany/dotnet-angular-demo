using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Services.Repos;

public class OrderRepo : IOrderRepo
{
	private readonly DbContext _context;

	public OrderRepo(DbContext context)
	{
		_context = context;
	}

	public List<Order> GetAllOrders()
	{
		return _context.Set<Order>()
			.Join(_context.Set<Stock>(),
			order => order.StockId,
			stock => stock.Id,
			(order, stock) => new Order{
				Id = order.Id,
				StockName = stock.Name,
				Price = order.Price,
				UserName = order.UserName,
				Quantity = order.Quantity
			}).ToList();
	}

	public Order CreateOrder(Order order)
	{
		var stock = _context.Set<Stock>().Find(order.StockId) ?? throw new Exception();
		order.Price = stock.Price * order.Quantity;
        _context.Set<Order>().Add(order);
		_context.SaveChanges();
		return order;
	}
}


