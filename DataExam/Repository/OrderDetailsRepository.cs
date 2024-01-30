using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class OrderDetailsRepository : IRepo<ProductEntity>
    {
        private readonly CandyStoreContext _context;

        public OrderDetailsRepository(CandyStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<OrderDetailsEntity> AddAsync(OrderDetailsEntity orderDetails)
        {
            await _context.OrderDetails.AddAsync(orderDetails);
            await _context.SaveChangesAsync();
            return orderDetails;
        }

        public async Task<OrderDetailsEntity> GetByIdAsync(int id)
        {
            return await _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
                .FirstOrDefaultAsync(od => od.OrderDetailsId == id);
        }

        public async Task UpdateAsync(OrderDetailsEntity orderDetails)
        {
            _context.OrderDetails.Update(orderDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails != null)
            {
                _context.OrderDetails.Remove(orderDetails);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OrderDetailsEntity>> GetAllAsync()
        {
            return await _context.OrderDetails
                .Include(od => od.Order)
                .Include(od => od.Product)
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
