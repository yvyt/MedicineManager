using System;
using System.Collections.Generic;

namespace MedicineManager.Data
{
    public partial class Order
    {
        public Order()
        {
            OrderProducts = new HashSet<OrderProduct>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateOnly? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public float Total { get; set; }
        public string Status { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
