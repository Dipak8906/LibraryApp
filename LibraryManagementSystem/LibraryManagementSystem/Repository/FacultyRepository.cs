using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository
{
    public class FacultyRepository : IFaculty
    {
        private LibraryDbContext _context;
        public FacultyRepository(LibraryDbContext context)
        {
            _context = context;
        }
        public async Task AddFaculty(Faculty faculty)
        {
            await _context.Faculties.AddAsync(faculty);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFacultyAsync(int facultyId)
        {
            var bk = new Faculty()
            {
                FacultyId = facultyId
            };
            _context.Faculties.Remove(bk);
            await _context.SaveChangesAsync();
        }

        public async Task<Faculty> GetFaculty(int facultyId)
        {
            var book = await _context.Faculties.FindAsync(facultyId);
            return book;
        }

        public async Task<IEnumerable<Faculty>> GetFacultyAsync()
        {
            var records = await _context.Faculties.ToListAsync();
            return records;
        }
        
        public async Task<Faculty> UpdateFacultyAsync(Faculty faculty)
        {
            var bk = new Faculty()
            {
                FacultyName=faculty.FacultyName,
                FacultyEmail=faculty.FacultyEmail,
                FacultyPhone=faculty.FacultyPhone,
                FacultyAddress=faculty.FacultyAddress,
                Designation=faculty.Designation



            };
            _context.Faculties.Update(bk);
            await _context.SaveChangesAsync();
            return bk;
        }
    }
}
