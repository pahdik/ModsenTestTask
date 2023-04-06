using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    public class BookRepository:IBookRepository
    {
        private DataContext Context;

        public BookRepository(DataContext _context)
        {
            Context = _context;
        }
        public async Task<Book> GetByIdAsync(int id)
        {
            return await Context.Books.FirstOrDefaultAsync(x=>x.Id==id);
        }
        public async Task<Book> GetByISBNAsync(string ISBN)
        {
            return await Context.Books.FirstOrDefaultAsync(x => x.ISBN == ISBN);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await Context.Books.ToListAsync();
        }


        public async Task AddAsync(Book model)
        {
            if (model == null) { return; }
            await Context.Books.AddAsync(model);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book model)
        {
            //if(model == null) { return; }
            var book = await Context.Books.FirstOrDefaultAsync(x => x.Id == model.Id);
            //if (book == null) { return; }
            book.ISBN = model.ISBN;
            book.AuthorName = model.AuthorName;
            book.Description= model.Description;    
            book.Genre = model.Genre;
            
            await Context.SaveChangesAsync();
        }


        public async Task DeleteByIdAsync(int id)
        {
            
            var book = await Context.Books.FirstAsync(x=>x.Id==id);
            if (book == null) { return; }
            Context.Books.Remove(book);
            await Context.SaveChangesAsync();
        }

    }
}
