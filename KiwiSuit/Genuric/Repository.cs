using KiwiSuit.Data;
using KiwiSuit.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace KiwiSuit.Genuric
{
    public class Repository<T> : IRepositoy<T> where T : class
    {

        private readonly DataContext _context;
        private readonly DbSet<T> _entities;
        public Repository(DataContext context)
        {
            _context = context;
             //_entities = context.Set<T>();
        }


        public void AdDAsync(T t)
        {
            _entities.Add(t);
        }

        public async Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public void UpdateAsync(int id, T t)
        {
            _entities.AddOrUpdate(_entities.Find(id), t);
        }
    }
}
