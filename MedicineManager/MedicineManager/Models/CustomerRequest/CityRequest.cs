using System.ComponentModel.DataAnnotations;

namespace MedicineManager.Models.CustomerRequest
{
    public class CityRequest
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;

    }
}
