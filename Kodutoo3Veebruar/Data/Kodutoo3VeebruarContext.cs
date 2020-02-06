using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kodutoo3Veebruar.Models;

namespace Kodutoo3Veebruar.Data
{
    public class Kodutoo3VeebruarContext : DbContext
    {
        public Kodutoo3VeebruarContext (DbContextOptions<Kodutoo3VeebruarContext> options)
            : base(options)
        {
        }

        public DbSet<Kodutoo3Veebruar.Models.Movie> Movie { get; set; }
    }
}
