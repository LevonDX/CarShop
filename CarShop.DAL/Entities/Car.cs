using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.DAL.Entities
{
    public class Car : EntityBase
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int? Year { get; set; }
        public decimal? Price { get; set; }

        [ForeignKey("Store")]
        public int? StoreId { get; set; }
        public Store? Store { get; set; }
    }
}