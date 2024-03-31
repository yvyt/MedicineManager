using MedicineManager.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace MedicineManager.Services.Customer
{
    public class AddressRepository
    {
        private readonly medicineContext _context;

        public AddressRepository(medicineContext context)
        {
            _context = context;
        }
        public async Task<Address> Add(Address address)
        {
            await _context.Set<Address>().AddAsync(address);
            try
            {
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();

                return address;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<List<Address>> GetAll()
        {
            var address=await (_context.Set<Address>().AsNoTracking().Include(u=>u.City).Include(u=>u.District)
                .Include(u=>u.Ward).Include(u=>u.User))
                .AsQueryable().ToListAsync();
            return address;
        }
        public async Task<Address> GetById(int id)
        {
            var address = await (_context.Set<Address>().AsNoTracking().Include(u => u.City).Include(u => u.District)
                .Include(u => u.Ward).Include(u => u.User)).AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            return address;
        }

        public async Task<List<Address>> FindByUser(int userId)
        {
            var address = await (_context.Set<Address>().AsNoTracking().Include(u => u.City).Include(u => u.District)
                .Include(u => u.Ward).Include(u => u.User)).AsQueryable().Where(u=>u.UserId==userId).ToListAsync();
            return address;
        }

        internal async Task<Address> UpdateAddress(Address add)
        {
             _context.Set<Address>().Update(add);
            try
            {
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();

                return add;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }

        internal async Task DeleteAddress(Address address)
        {
            
            _context.Set<Address>().Remove(address);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        internal async Task DeleteRange(List<Address> address)
        {
            _context.RemoveRange(address);
            try
            {
                await _context.SaveChangesAsync();
                _context.ChangeTracker.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
    }
}
