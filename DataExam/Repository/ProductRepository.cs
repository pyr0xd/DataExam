using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories
{
    public class ProductRepository : IRepo<ProductEntity>
    {
        private readonly CandyStoreContext _context;

        public ProductRepository(CandyStoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<ProductEntity> AddAsync(ProductEntity product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                
                .ToListAsync();
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
