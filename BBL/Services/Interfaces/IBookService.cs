using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Library.BLL.DTO;


namespace Library.BBL.Services.Interfaces
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBook();
        public Task<Book> GetBookById(int id);
        public Task<Book> GetBookByISBN(string ISBN);
        public Task AddBook(BookDTO model);
        public Task UpdateBook(BookDTO model);
        public Task DeleteBook(int id);


    }
}
