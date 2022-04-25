using LibraryManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Interface
{
   public interface IDesignation
    {
        Task<IEnumerable<Designation>> GetDesignationAsync();
        Task<Designation> GetDesignation(int designationId);
        Task AddDesignation(Designation designation);
        Task<Designation> UpdateDesignationAsync(Designation designation);
        Task DeleteDesignationAsync(int designationId);
    }
}
