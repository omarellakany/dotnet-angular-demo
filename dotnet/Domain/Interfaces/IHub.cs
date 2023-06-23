using Domain.Models;

namespace Domain.Interfaces;

public interface IHub
{
    Task UpdateStockPrice(Stock stock);
}