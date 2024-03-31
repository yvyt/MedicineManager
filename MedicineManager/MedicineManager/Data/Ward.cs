using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedicineManager.Data
{
    public partial class Ward
    {
        public Ward()
        {
            Addresses = new HashSet<Address>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int DistrictId { get; set; }

        public virtual District District { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<Address> Addresses { get; set; }
    }
}
