using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedicineManager.Data
{
    public partial class District
    {
        public District()
        {
            Addresses = new HashSet<Address>();
            Wards = new HashSet<Ward>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int CityId { get; set; }

        public virtual City City { get; set; } = null!;
        [JsonIgnore] public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }
    }
}
