using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository
{
    public class EbookRepository : IEbook
    {
        private LibraryDbContext _context;
        public EbookRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddEbook(Ebook eBook)
        {
            await _context.Ebooks.AddAsync(eBook);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEbookAsync(int eBookId)
        {
            var bk = new Ebook()
            {
               EbookId = eBookId
            };
            _context.Ebooks.Remove(bk);
            await _context.SaveChangesAsync();
        }

        public async Task<Ebook> GetEbook(int eBookId)
        {
            var book = await _context.Ebooks.FindAsync(eBookId);
            return book;
        }

        public async Task<IEnumerable<Ebook>> GetEbookAsync()
        {
            var records = await _context.Ebooks.ToListAsync();
            return records;
        }

        public async Task<Ebook> UpdateEbookAsync(Ebook eBook)
        {
            var bk = new Ebook()
            {
                EbookId=eBook.EbookId,
                EbookName=eBook.EbookName,
                ISBN=eBook.ISBN,
                Description=eBook.Description,
                Publisher=eBook.Publisher,
                Author=eBook.Author



            };
            _context.Ebooks.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
