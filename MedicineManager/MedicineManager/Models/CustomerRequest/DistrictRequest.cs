using MedicineManager.Data;

namespace MedicineManager.Models.CustomerRequest
{
    public class DistrictRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CityId { get; set; }
    }
}
