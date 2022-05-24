using Microsoft.EntityFrameworkCore;
using NetAPI.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    
        public DbSet<Nota> Notas { get; set; }
    }
}
