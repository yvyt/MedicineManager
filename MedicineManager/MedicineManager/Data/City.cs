using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MedicineManager.Data
{
    public partial class City
    {
        public City()
        {
            Addresses = new HashSet<Address>();
            Districts = new HashSet<District>();
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        [JsonIgnore] public virtual ICollection<Address> Addresses { get; set; }
        [JsonIgnore] public virtual ICollection<District> Districts { get; set; }
    }
}
