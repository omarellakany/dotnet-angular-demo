using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Services.Hubs;

namespace Services.Repos;

public class StockRepo : IStockRepo
{
    private readonly DbContext _context;
    private readonly IHubContext<StocksHub, IHub> _hubContext;


    public StockRepo(DbContext context, IHubContext<StocksHub, IHub> hubContext)
    {
        _context = context;
        _hubContext = hubContext;

        if (_context.Set<Stock>().Any()) return;

        _context.Set<Stock>().AddRange(new List<Stock> {
            new Stock { Id = 1, Name = "Vianet", Price = Random.Shared.Next(100) },
            new Stock { Id = 2, Name = "Agritek", Price = Random.Shared.Next(100) },
            new Stock { Id = 3, Name = "Akamai", Price = Random.Shared.Next(100) },
            new Stock { Id = 4, Name = "Baidu", Price = Random.Shared.Next(100) },
            new Stock { Id = 5, Name = "Blinkx", Price = Random.Shared.Next(100) },
            new Stock { Id = 6, Name = "Blucora", Price = Random.Shared.Next(100) },
            new Stock { Id = 7, Name = "Boingo", Price = Random.Shared.Next(100) },
            new Stock { Id = 8, Name = "Brainybrawn", Price = Random.Shared.Next(100) },
            new Stock { Id = 9, Name = "Carbonite", Price = Random.Shared.Next(100) },
            new Stock { Id = 10, Name = "China Finance", Price = Random.Shared.Next(100) },
            new Stock { Id = 11, Name = "ChinaCache", Price = Random.Shared.Next(100) },
            new Stock { Id = 12, Name = "ADR", Price = Random.Shared.Next(100) },
            new Stock { Id = 13, Name = "ChitrChatr", Price = Random.Shared.Next(100) },
            new Stock { Id = 14, Name = "Cnova", Price = Random.Shared.Next(100) },
            new Stock { Id = 15, Name = "Cogent", Price = Random.Shared.Next(100) },
            new Stock { Id = 16, Name = "Crexendo", Price = Random.Shared.Next(100) },
            new Stock { Id = 17, Name = "CrowdGather", Price = Random.Shared.Next(100) },
            new Stock { Id = 18, Name = "EarthLink", Price = Random.Shared.Next(100) },
            new Stock { Id = 19, Name = "Eastern", Price = Random.Shared.Next(100) },
            new Stock { Id = 20, Name = "ENDEXX", Price = Random.Shared.Next(100) },
            new Stock { Id = 21, Name = "Envestnet", Price = Random.Shared.Next(100) },
            new Stock { Id = 22, Name = "Epazz", Price = Random.Shared.Next(100) },
            new Stock { Id = 23, Name = "FlashZero", Price = Random.Shared.Next(100) },
            new Stock { Id = 24, Name = "Genesis", Price = Random.Shared.Next(100) },
            new Stock { Id = 25, Name = "InterNAP", Price = Random.Shared.Next(100) },
            new Stock { Id = 26, Name = "MeetMe", Price = Random.Shared.Next(100) },
            new Stock { Id = 27, Name = "Netease", Price = Random.Shared.Next(100) },
            new Stock { Id = 28, Name = "Qihoo", Price = Random.Shared.Next(100) },
        });
        _context.SaveChanges();
    }

    public List<Stock> GetAllStocks()
    {
        return _context.Set<Stock>().ToList();
    }

    public Stock UpdateStockPrice(int id, decimal price) {
        var foundStock = _context.Set<Stock>().Find(id) ?? throw new Exception();
        foundStock.Price = price;
        _context.SaveChanges();
        _hubContext.Clients.All.UpdateStockPrice(foundStock);
        return foundStock;
    }
}

