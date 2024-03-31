using MedicineManager.Data;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MedicineManager.Models.CustomerRequest
{
    public class AddressRequest
    {
        public int Id { get; set; }
        [Required]
        public int CityId { get; set; }
        [Required]
        public int DistrictId { get; set; }
        [Required]
        public int WardId { get; set; }
        [Required]
        public string Address1 { get; set; } = null!;
        [Required]
        public int UserId { get; set; }
        public bool? IsDefault { get; set; } = true;
    }
}
