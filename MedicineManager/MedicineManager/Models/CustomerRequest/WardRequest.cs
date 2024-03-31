namespace MedicineManager.Models.CustomerRequest
{
    public class WardRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }
    }
}
