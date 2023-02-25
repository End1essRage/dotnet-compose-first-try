using Microsoft.EntityFrameworkCore;
using CatalogService.Data.DataAccess.Interfaces;

namespace CatalogService.Data.DataAccess.Classes
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync<TId>(TId id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
