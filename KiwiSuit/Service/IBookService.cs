using KiwiSuit.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using KiwiSuit.DTO;

namespace KiwiSuit.Service
{
    public interface IBookService
    {
        Task<List<BookDTO>> GetAllBooksAsync();
        Task<BookDTO> GetBookByIdAsync(int id);
        void AddBookAsync(BookDTO bookDTO);
        void UpdateBookAsync(int id, BookDTO bookDTO);
        Task DeleteBookAsync(int id);
    }
}

