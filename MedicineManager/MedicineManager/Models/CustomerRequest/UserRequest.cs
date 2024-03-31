using System.ComponentModel.DataAnnotations;

namespace MedicineManager.Models.CustomerRequest
{
    public class UserRequest
    {
        public int Id { get; set; }
      
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        [Phone]
        public string PhoneNumber { get; set; } = null!;
        public bool? IsActive { get; set; } = true;
        public DateTime? UpdateAt { get; set; } = DateTime.Now;
    }
}
