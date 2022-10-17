using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EC2_1701497.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EC2_1701497.Data
{
    public class EC2_1701497Context : IdentityDbContext
    {
        public EC2_1701497Context (DbContextOptions<EC2_1701497Context> options)
            : base(options)
        {
        }

        public DbSet<EC2_1701497.Models.Book> Book { get; set; }

        public DbSet<EC2_1701497.Models.Order> Order { get; set; }
    }
}
