using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IBookRepository
    {
        public Task<Book> GetByIdAsync(int id);

        public Task<List<Book>> GetAllAsync();
        public Task<Book> GetByISBNAsync(string ISBN);

        public Task AddAsync(Book model);

        public Task UpdateAsync(Book model);


        public Task DeleteByIdAsync(int id);
    }
}
