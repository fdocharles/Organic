using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organic.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int OrderNo { get; set; }
        public bool IsPlaced { get; set; }
    }
}
