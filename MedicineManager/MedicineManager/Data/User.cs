using System;
using System.Collections.Generic;

namespace MedicineManager.Data
{
    public partial class User
    {
        public User()
        {
            Addresses = new HashSet<Address>();
            Carts = new HashSet<Cart>();
            CategoryCreateByNavigations = new HashSet<Category>();
            CategoryUpdateByNavigations = new HashSet<Category>();
            ManufactoryCreateByNavigations = new HashSet<Manufactory>();
            ManufactoryUpdateByNavigations = new HashSet<Manufactory>();
            Orders = new HashSet<Order>();
            ProductCreateByNavigations = new HashSet<Product>();
            ProductUpdateByNavigations = new HashSet<Product>();
            UnitCreateByNavigations = new HashSet<Unit>();
            UnitUpdateByNavigations = new HashSet<Unit>();
        }

        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public bool? IsActive { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Category> CategoryCreateByNavigations { get; set; }
        public virtual ICollection<Category> CategoryUpdateByNavigations { get; set; }
        public virtual ICollection<Manufactory> ManufactoryCreateByNavigations { get; set; }
        public virtual ICollection<Manufactory> ManufactoryUpdateByNavigations { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Product> ProductCreateByNavigations { get; set; }
        public virtual ICollection<Product> ProductUpdateByNavigations { get; set; }
        public virtual ICollection<Unit> UnitCreateByNavigations { get; set; }
        public virtual ICollection<Unit> UnitUpdateByNavigations { get; set; }
    }
}
