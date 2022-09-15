using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiVeiculos.Models;

namespace WebApiVeiculos.Data
{
    public class WebApiVeiculosContext : DbContext
    {
        public WebApiVeiculosContext (DbContextOptions<WebApiVeiculosContext> options)
            : base(options)
        {
        }

        public DbSet<Veiculos> Veiculos { get; set; } = default!;
    }
}
