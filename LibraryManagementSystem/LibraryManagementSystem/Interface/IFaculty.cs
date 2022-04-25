using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interface
{
   public interface IFaculty
    {
        Task<IEnumerable<Faculty>> GetFacultyAsync();
        Task<Faculty> GetFaculty(int facultyId);
        Task AddFaculty(Faculty faculty);
        Task<Faculty> UpdateFacultyAsync(Faculty faculty);
        Task DeleteFacultyAsync(int facultyId);
    }
}
