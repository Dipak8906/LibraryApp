using LibraryManagementSystem.Interface;
using LibraryManagementSystem.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Repository
{
    public class SupplierRepository:ISupplier
    {
        private readonly LibraryDbContext _libraryDBContext;

        public SupplierRepository(LibraryDbContext libraryDBContext)
        {
            _libraryDBContext = libraryDBContext;
        }
        public async Task AddSupplier(Supplier supplier)
        {
            await _libraryDBContext.Suppliers.AddAsync(supplier);
            await _libraryDBContext.SaveChangesAsync();
        }

        public async Task DeleteSupplier(int supplierId)
        {
            Supplier supplier = new Supplier()
            {
                SupplierId = supplierId
            };
            _libraryDBContext.Suppliers.Remove(supplier);
            await _libraryDBContext.SaveChangesAsync();
        }

        public async Task<Supplier> GetSupplier(int supplierId)
        {
            return await _libraryDBContext.Suppliers.FindAsync(supplierId);
        }

        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            return await _libraryDBContext.Suppliers.ToListAsync();

        }

        public async Task<Supplier> UpdateSupplierDetail(Supplier supplier)
        {
            _libraryDBContext.Suppliers.Update(supplier);
            await _libraryDBContext.SaveChangesAsync();
            return supplier;
        }
    }
}
