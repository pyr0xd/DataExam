using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace ConsoleApp1.Repositories
{
    public class CartRepository : IRepo<ProductEntity>
    {
        private readonly CandyStoreContext _context;

        public CartRepository(CandyStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CartEntity> AddAsync(CartEntity cart)
        {
            await _context.Carts.AddAsync(cart);
            await _context.SaveChangesAsync();
            return cart;
        }

        public async Task<CartEntity> GetByIdAsync(int id)
        {
            return await _context.Carts
                                 .Include(c => c.CartItems)
                                 .FirstOrDefaultAsync(c => c.CartId == id);
        }

        public async Task UpdateAsync(CartEntity cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CartEntity>> GetAllAsync()
        {
            return await _context.Carts
                                 .Include(c => c.CartItems)
                                 .ToListAsync();
        }

        public Task<ProductEntity> AddAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<ProductEntity> IRepo<ProductEntity>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<ProductEntity>> IRepo<ProductEntity>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public ProductEntity GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductEntity> Find(Expression<Func<ProductEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Add(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<ProductEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductEntity entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<ProductEntity> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
