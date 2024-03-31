using System;
using System.Collections.Generic;

namespace MedicineManager.Data
{
    public partial class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public int Number { get; set; }
        public int Price { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual Product? Product { get; set; }
        public virtual User User { get; set; } = null!;
    }
}
