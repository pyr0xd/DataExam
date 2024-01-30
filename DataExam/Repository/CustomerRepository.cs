using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class CustomerRepository : IRepo<ProductEntity>
    {
        private readonly CandyStoreContext _context;

        public CustomerRepository(CandyStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CustomerEntity> AddAsync(CustomerEntity customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<CustomerEntity> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task UpdateAsync(CustomerEntity customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
        {
            return await _context.Customers.ToListAsync();
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
