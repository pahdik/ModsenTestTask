using DAL.Models;
using Library.BLL.DTO;


namespace Library.BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> GetBookByISBN(string ISBN);
        Task AddBook(BookAddDTO model);
        Task UpdateBook(BookUpdateDTO model);
        Task DeleteBook(int id);
    }


}
