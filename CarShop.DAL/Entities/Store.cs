using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.DAL.Entities
{
    public class Store : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }
}
