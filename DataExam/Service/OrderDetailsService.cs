using ConsoleApp1.Entities;

public class OrderDetailsService
{
    private Repo<OrderDetailsEntity> _orderDetailsRepo;

    public OrderDetailsService(Repo<OrderDetailsEntity> orderDetailsRepo)
    {
        _orderDetailsRepo = orderDetailsRepo;
    }

    public async Task<IEnumerable<OrderDetailsEntity>> GetAllOrderDetailsAsync()
    {
        return await _orderDetailsRepo.GetAllAsync();
    }

    public async Task<OrderDetailsEntity> GetOrderDetailsByIdAsync(int id)
    {
        return await _orderDetailsRepo.GetByIdAsync(id);
    }

    public async Task<OrderDetailsEntity> CreateOrderDetailsAsync(OrderDetailsEntity orderDetails)
    {
        await _orderDetailsRepo.AddAsync(orderDetails);
        return orderDetails;
    }

    public async Task UpdateOrderDetailsAsync(OrderDetailsEntity orderDetails)
    {
        await _orderDetailsRepo.UpdateAsync(orderDetails);
    }

    public async Task DeleteOrderDetailsAsync(int id)
    {
        await _orderDetailsRepo.DeleteAsync(id);
    }
}
