using ConsoleApp1.Entities;

public class CartItemService
{
    private Repo<CartItemEntity> _cartItemRepo;

    public CartItemService(Repo<CartItemEntity> cartItemRepo)
    {
        _cartItemRepo = cartItemRepo;
    }

    public async Task<IEnumerable<CartItemEntity>> GetAllCartItemsAsync()
    {
        return await _cartItemRepo.GetAllAsync();
    }

    public async Task<CartItemEntity> GetCartItemByIdAsync(int id)
    {
        return await _cartItemRepo.GetByIdAsync(id);
    }

    public async Task<CartItemEntity> CreateCartItemAsync(CartItemEntity cartItem)
    {
        await _cartItemRepo.AddAsync(cartItem);
        return cartItem;
    }

    public async Task UpdateCartItemAsync(CartItemEntity cartItem)
    {
        await _cartItemRepo.UpdateAsync(cartItem);
    }

    public async Task DeleteCartItemAsync(int id)
    {
        await _cartItemRepo.DeleteAsync(id);
    }
}
