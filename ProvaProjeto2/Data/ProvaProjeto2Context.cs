using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaProjeto2.Models;

namespace ProvaProjeto2.Data
{
    public class ProvaProjeto2Context : DbContext
    {
        public ProvaProjeto2Context (DbContextOptions<ProvaProjeto2Context> options)
            : base(options)
        {
        }

        public DbSet<ProvaProjeto2.Models.Cliente> Cliente { get; set; }

        public DbSet<ProvaProjeto2.Models.Ferramenta> Ferramenta { get; set; }
    }
}
