using System.Collections.Generic;
using System.Threading.Tasks;
using KiwiSuit.Models;


namespace KiwiSuit.Repositery
{
    public interface IBookRepositery
    {
        Task<List<Books>> GetAllBooksAsync();
        Task<Books> GetBookByIdAsync(int id);
        Task AddBookAsync(Books book);
        Task UpdateBookAsync(int id, Books book);
        Task DeleteBookAsync(int id);
    }
}

