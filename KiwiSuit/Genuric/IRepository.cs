using KiwiSuit.Models;

namespace KiwiSuit.Genuric
{
    public interface IRepositoy<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        void AdDAsync(T t);
        void UpdateAsync(int id, T t);
        Task DeleteAsync(int id);


    }
}
