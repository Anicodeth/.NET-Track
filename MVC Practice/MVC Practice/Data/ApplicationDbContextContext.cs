using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVC_Practice.Models;

namespace MVC_Practice.Data
{
    public class ApplicationDbContextContext : DbContext
    {
        public ApplicationDbContextContext (DbContextOptions<ApplicationDbContextContext> options)
            : base(options)
        {
        }

        public DbSet<MVC_Practice.Models.Joke> Joke { get; set; } = default!;
    }
}
