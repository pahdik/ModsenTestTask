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
    public class BookService:IBookService
    {
        private IBookRepository bookRepository;
        private IMapper mapper;
        public BookService(IBookRepository rep,IMapper map ) 
        {
            bookRepository = rep;
            mapper = map;
        }
        public async Task<List<Book>> GetAllBook()
        {
            return await bookRepository.GetAllAsync();
        }
        public async Task<Book> GetBookById(int id)
        {
            return await bookRepository.GetByIdAsync(id);
        }
        public async Task<Book> GetBookByISBN(string ISBN)
        {
            return await bookRepository.GetByISBNAsync(ISBN);
        }
        public async Task AddBook(BookAddDTO model)
        {
            if (model == null) return;
            Book book = mapper.Map<Book>(model);
            book.Id = 0;
            book.ReceivingTime = DateTime.Now;
            book.TimeToReturn = DateTime.Now.AddDays(7);
            await bookRepository.AddAsync(book);
        }
        public async Task UpdateBook(BookUpdateDTO model)
        {
            if (model == null) return;
            var newBook= mapper.Map<Book>(model);
            if (await bookRepository.GetByIdAsync(model.Id) == null) return;
            await bookRepository.UpdateAsync(newBook);
        }
        public async Task DeleteBook(int id)
        {
            Book book = await bookRepository.GetByIdAsync(id);
            if (book == null) return;
            await bookRepository.DeleteByIdAsync(id);
        }
    }
}
