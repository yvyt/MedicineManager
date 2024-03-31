using MedicineManager.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicineManager.Services.Customer
{
    public class UserRepository
    {
        private readonly medicineContext _context;

        public UserRepository(medicineContext context)
        {
            _context = context;
        }
        public async Task<User> Add(User user)
        {
            await _context.Set<User>().AddAsync(user);
            try
            {
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<List<User>> GetAll()
        {
            var users = await (_context.Set<User>().AsNoTracking().Include(dc => dc.Addresses)
               .Include(c => c.Carts).Include(c => c.Orders)).AsQueryable().ToListAsync();
            return users;
        }
        public async Task<User> FindUser(int id)
        {
            var us = await (_context.Set<User>().AsNoTracking().Include(dc => dc.Addresses).Include(c => c.Carts).Include(c => c.Orders))
                    .AsQueryable().FirstOrDefaultAsync(x => x.Id == id);
            return us;
        }
        public async Task<User> UpdateUser(User user)
        {
            _context.Set<User>().Update(user);
            try
            {
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }

        internal async Task DeleteUser(User us)
        {
            _context.Set<User>().Remove(us);
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
    }
}
