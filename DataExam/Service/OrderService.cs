using ConsoleApp1.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

public class OrderService
{
    private Repo<OrderEntity> _orderRepo;

    public OrderService(Repo<OrderEntity> orderRepo)
    {
        _orderRepo = orderRepo;
    }

    public async Task<IEnumerable<OrderEntity>> GetAllOrdersAsync()
    {
        return await _orderRepo.GetAllAsync();
    }

    public async Task<OrderEntity> GetOrderByIdAsync(int orderId)
    {
        return await _orderRepo.GetByIdAsync(orderId);
    }

    public async Task<OrderEntity> CreateOrderAsync(OrderEntity order)
    {
        await _orderRepo.AddAsync(order);
        return order;
    }

    public async Task UpdateOrderAsync(OrderEntity order)
    {
        await _orderRepo.UpdateAsync(order);
    }

    public async Task DeleteOrderAsync(int orderId)
    {
        await _orderRepo.DeleteAsync(orderId);
    }
}
