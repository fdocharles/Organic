using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using organic.Models;

namespace organic.Data
{
    public class organicContext : DbContext
    {
        public organicContext (DbContextOptions<organicContext> options)
            : base(options)
        {
        }

        public DbSet<organic.Models.Cart> Cart { get; set; }

        public DbSet<organic.Models.Comment> Comment { get; set; }

        public DbSet<organic.Models.Customer> Customer { get; set; }

        public DbSet<organic.Models.Order> Order { get; set; }

        public DbSet<organic.Models.Product> Product { get; set; }
    }
}
