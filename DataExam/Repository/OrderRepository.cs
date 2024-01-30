using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class OrderRepository : IRepo<ProductEntity>
    {
        private readonly CandyStoreContext _context;

        public OrderRepository(CandyStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<OrderEntity> AddAsync(OrderEntity order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<OrderEntity> GetByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .FirstOrDefaultAsync(o => o.OrderId == id);
        }

        public async Task UpdateAsync(OrderEntity order)
        {
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderEntity>> GetAllAsync()
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
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
