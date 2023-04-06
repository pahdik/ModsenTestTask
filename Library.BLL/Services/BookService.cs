using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Library.BLL.Services.Interfaces;
using DAL.Models;
using Library.BLL.DTO;
using AutoMapper;
using System.Runtime.ExceptionServices;

namespace Library.BLL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<Book> GetBookByISBN(string isbn)
        {
            return await _bookRepository.GetByISBNAsync(isbn);
        }

        public async Task AddBook(BookAddDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var book = _mapper.Map<Book>(model);
            book.Id = 0;
            book.ReceivingTime = DateTime.Now;
            book.TimeToReturn = DateTime.Now.AddDays(7);

            await _bookRepository.AddAsync(book);
        }

        public async Task UpdateBook(BookUpdateDTO model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var existingBook = await _bookRepository.GetByIdAsync(model.Id);
            if (existingBook == null)
            {
                throw new ArgumentException("Book not found", nameof(model));
            }

            var updatedBook = _mapper.Map<Book>(model);
            await _bookRepository.UpdateAsync(updatedBook);
        }

        public async Task DeleteBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book != null)
            {
                await _bookRepository.DeleteByIdAsync(id);
            }
        }
    }

}
