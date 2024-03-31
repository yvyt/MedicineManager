using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MedicineManager.Data
{
    public partial class Address
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int DistrictId { get; set; }
        public int WardId { get; set; }
        public string Address1 { get; set; } = null!;
        public int UserId { get; set; }
        public bool? IsDefault { get; set; }

        public virtual City? City { get; set; }
        public virtual District? District { get; set; }
        [JsonIgnore] public virtual User? User { get; set; } 
        public virtual Ward? Ward { get; set; } 
    }
}
