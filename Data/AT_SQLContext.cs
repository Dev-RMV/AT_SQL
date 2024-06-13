using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AT_SQL.Models;

namespace AT_SQL.Data
{
    public class AT_SQLContext : DbContext
    {
        public AT_SQLContext (DbContextOptions<AT_SQLContext> options)
            : base(options)
        {
        }

        public DbSet<AT_SQL.Models.Livro> Livro { get; set; } = default!;
    }
}
