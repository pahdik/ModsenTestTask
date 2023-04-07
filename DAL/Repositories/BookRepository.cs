using DAL.Data;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;

        public BookRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> GetByISBNAsync(string isbn)
        {
            return await _context.Books.FirstOrDefaultAsync(x => x.ISBN == isbn);
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task AddAsync(Book model)
        {
            _context.Books.Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book model)
        {
            var book = await _context.Books.FindAsync(model.Id);
            if (book == null)
            {
                throw new ArgumentNullException("Book not found", nameof(model));
            }
            book.ISBN = model.ISBN;
            book.AuthorName = model.AuthorName;
            book.Description = model.Description;
            book.Genre = model.Genre;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
    }

}
