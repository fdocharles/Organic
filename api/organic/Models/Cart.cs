using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organic.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public int Tax { get; set; }
        public decimal Total { get; set; }
    }
}
