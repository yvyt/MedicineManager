using System;
using System.Collections.Generic;

namespace MedicineManager.Data
{
    public partial class Product
    {
        public Product()
        {
            Carts = new HashSet<Cart>();
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Category { get; set; }
        public int Manufactory { get; set; }
        public string? Description { get; set; }
        public double? Print { get; set; }
        public string? NoteProduct { get; set; }
        public DateOnly ExpDate { get; set; }
        public bool? IsActive { get; set; }
        public int NumberStock { get; set; }
        public int CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int UpdateBy { get; set; }

        public virtual Category CategoryNavigation { get; set; } = null!;
        public virtual User CreateByNavigation { get; set; } = null!;
        public virtual Manufactory ManufactoryNavigation { get; set; } = null!;
        public virtual User UpdateByNavigation { get; set; } = null!;
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
