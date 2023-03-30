using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Models;
using System.Numerics;

namespace DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }
        public DbSet<Book> Books {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(p => p.AuthorName).HasMaxLength(50);
            modelBuilder.Entity<Book>().Property(p => p.ISBN).HasMaxLength(100);
            modelBuilder.Entity<Book>().Property(p => p.Description).HasMaxLength(500);
            modelBuilder.Entity<Book>().Property(p => p.Genre).HasMaxLength(20);
        }

    }
}
