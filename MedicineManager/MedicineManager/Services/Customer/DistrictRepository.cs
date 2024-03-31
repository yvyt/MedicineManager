using MedicineManager.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicineManager.Services.Customer
{
    public class DistrictRepository
    {
        private readonly medicineContext _context;

        public DistrictRepository(medicineContext context)
        {
            _context = context;
        }
        public async Task<District> getById (int district_id)
        {
            var result = await _context.Set<District>()
                        .AsNoTracking()
                        .Include(x => x.City)
                        .Include(x => x.Wards)
                        .FirstOrDefaultAsync(x => x.Id == district_id);
            return result;
        }
        public async Task<District> Add(District district)
        {
            await _context.Districts.AddAsync(district);
            try
            {
                await _context.SaveChangesAsync();
                return district;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<District> Update(District d)
        {
            _context.Districts.Update(d);
                 try
            {
                await _context.SaveChangesAsync();
                return d;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<List<District>> getAll()
        {
            return await (_context.Set<District>().AsNoTracking().Include(x => x.City).Include(x => x.Wards))
                            .AsQueryable().ToListAsync();
        }

        public async Task<List<District>> getByCityId(int city_id)
        {
            return await (_context.Set<District>().AsNoTracking().Include(x => x.City).Include(x => x.Wards))
                            .AsQueryable().Where(x => x.CityId==city_id).ToListAsync();
        }

        public async Task Delete(District district)
        {
            _context.Districts.Remove(district);
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
