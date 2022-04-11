using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace organic.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerComment { get; set; }
        public int Rating { get; set; }
    }
}
