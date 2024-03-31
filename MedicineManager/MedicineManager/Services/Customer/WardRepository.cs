using MedicineManager.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicineManager.Services.Customer
{
    public class WardRepository
    {
        private readonly medicineContext _context;

        public WardRepository(medicineContext context)
        {
            _context = context;
        }
        public async Task<Ward> getById(int ward_id)
        {
            return await (_context.Set<Ward>().AsNoTracking().Include(x => x.District))
                .AsQueryable().FirstOrDefaultAsync(x => x.Id == ward_id);
        }
        public async Task<Ward> Add(Ward ward)
        {
            _context.Wards.Add(ward);
            try
            {
                await _context.SaveChangesAsync();
                return ward;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<Ward> Update(Ward ward)
        {
            _context.Wards.Update(ward);
            try
            {
                await _context.SaveChangesAsync();
                return ward;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                _context.ChangeTracker.Clear();
                throw new Exception(ex.ToString());
            }
        }
        public async Task<List<Ward>> getAll()
        {
            return await (_context.Set<Ward>().AsNoTracking().Include(x=>x.District)).AsQueryable().ToListAsync();  
        }
        public async Task<List<Ward>> getByDistrictId(int id)
        {
            return await (_context.Set<Ward>().AsNoTracking().Include(x => x.District)).AsQueryable().Where(x=>x.DistrictId==id).ToListAsync();

        }
        public async Task Delete(Ward w)
        {
            _context.Wards.Remove(w);
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
