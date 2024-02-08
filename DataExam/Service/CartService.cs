using ConsoleApp1.Entities;

public class CartService 
{
    private Repo<CartEntity> _cartRepo;

    public CartService(Repo<CartEntity> cartRepo)
    {
        _cartRepo = cartRepo;
    }

    public async Task<IEnumerable<CartEntity>> GetAllCartsAsync()
    {
        return await _cartRepo.GetAllAsync();
    }

    public async Task<CartEntity> GetCartByIdAsync(int id)
    {
        return await _cartRepo.GetByIdAsync(id);
    }

    public async Task<CartEntity> CreateCartAsync(CartEntity cart)
    {
        await _cartRepo.AddAsync(cart);
        return cart;
    }

    public async Task UpdateCartAsync(CartEntity cart)
    {
        await _cartRepo.UpdateAsync(cart);
    }

    public async Task DeleteCartAsync(int id)
    {
        await _cartRepo.DeleteAsync(id);
    }
}
