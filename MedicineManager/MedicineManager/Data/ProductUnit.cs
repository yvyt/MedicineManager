using System;
using System.Collections.Generic;

namespace MedicineManager.Data
{
    public partial class ProductUnit
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public int CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int? UpdateBy { get; set; }

        public virtual User CreateByNavigation { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual Unit Unit { get; set; } = null!;
        public virtual User? UpdateByNavigation { get; set; }
    }
}
