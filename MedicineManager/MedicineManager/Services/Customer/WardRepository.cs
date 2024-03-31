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
            return await _context.Wards.FirstOrDefaultAsync(x => x.Id == ward_id);
        }
    }
}
