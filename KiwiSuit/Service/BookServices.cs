using AutoMapper;
using KiwiSuit.Models;
using KiwiSuit.Repositery;
using KiwiSuit.Data;
using KiwiSuit.DTO;

namespace KiwiSuit.Service
{
    public class BookServices : IBookService
    {
        private readonly IMapper _mapper;
        private readonly IBookRepositery _bookRepository;


        public BookServices(IMapper mapper, IBookRepositery bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public void AddBookAsync(BookDTO bookDTO)
        {
            var book = _mapper.Map<Books>(bookDTO);
            _bookRepository.AddBookAsync(book);

        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task<List<BookDTO>> GetAllBooksAsync()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            return _mapper.Map<List<BookDTO>>(books);
        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return _mapper.Map<BookDTO>(book);
        }

        public async void UpdateBookAsync(int id, BookDTO bookDTO)
        {
            var existingBook = await _bookRepository.GetBookByIdAsync(id);
            if (existingBook == null)
                return;

            _mapper.Map(bookDTO, existingBook);

            _bookRepository.UpdateBookAsync(id, existingBook);
        }
    }
}
