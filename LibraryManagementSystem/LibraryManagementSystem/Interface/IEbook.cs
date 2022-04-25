using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interface
{
    public interface IEbook
    {
        Task<IEnumerable<Ebook>> GetEbookAsync();
        Task<Ebook> GetEbook(int eBookId);
        Task AddEbook(Ebook eBook);
        Task<Ebook> UpdateEbookAsync(Ebook eBookId);
        Task DeleteEbookAsync(int eBookId);
    }
}
