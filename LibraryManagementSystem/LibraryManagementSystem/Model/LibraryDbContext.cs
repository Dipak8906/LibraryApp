using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Model
{
    public class LibraryDbContext: DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookStatus> BookStatus { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Ebook> Ebooks { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Issue>Issues { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

    }
}
