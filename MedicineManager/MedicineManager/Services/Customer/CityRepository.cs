using MedicineManager.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicineManager.Services.Customer
{
    public class CityRepository
    {
        private readonly medicineContext _context;

        public CityRepository(medicineContext context)
        {
            _context = context;
        }

        public async Task<City> getById(int city_id)
        {
            return await( _context.Cities.AsNoTracking().Include(d=>d.Addresses).Include(d=>d.Districts)).AsQueryable().FirstOrDefaultAsync(x => x.Id == city_id);
        } 
        public async Task<City> Add(City c)
        {
            _context.Cities.Add(c);
            try
            {
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<City> Update(City c)
        {
            _context.Cities.Update(c);
            try
            {
                await _context.SaveChangesAsync();
                return c;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<List<City>> getAll()
        {
            return await _context.Cities.ToListAsync();
        }

        internal async Task Delete(City ct)
        {
            _context.Cities.Remove(ct);
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
