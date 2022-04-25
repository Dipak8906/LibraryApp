using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository
{
    public class BookStatusRepository : IBookStatus
    {
        private LibraryDbContext _context;
        public BookStatusRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddBookStatus(BookStatus bookStatus)
        {
            await _context.BookStatus.AddAsync(bookStatus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookStatusAsync(int bookStatusId)
        {
            var bk = new BookStatus()
            {
                BookStatusId = bookStatusId
            };
            _context.BookStatus.Remove(bk);
            await _context.SaveChangesAsync();
        }

        public async Task<BookStatus> GetBookStatus(int bookStatusId)
        {
            var book = await _context.BookStatus.FindAsync(bookStatusId);
            return book;
        }

        public async Task<IEnumerable<BookStatus>> GetBookStatusAsync()
        {
            var records = await _context.BookStatus.ToListAsync();
            return records;
        }

        public async Task<BookStatus> UpdateBookStatusAsync(BookStatus bookStatus)
        {
            var bk = new BookStatus()
            {
               Status=bookStatus.Status
               

            };
            _context.BookStatus.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
