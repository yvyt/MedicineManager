using System;
using System.Collections.Generic;

namespace MedicineManager.Data
{
    public partial class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string Abbreviation { get; set; } = null!;
        public int CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public int UpdateBy { get; set; }

        public virtual User CreateByNavigation { get; set; } = null!;
        public virtual User UpdateByNavigation { get; set; } = null!;
    }
}
