using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiFarmacia.Models;

namespace ApiFarmacia.Data
{
    public class ApiFarmaciaContext : DbContext
    {
        public ApiFarmaciaContext (DbContextOptions<ApiFarmaciaContext> options)
            : base(options)
        {
        }

        public DbSet<ApiFarmacia.Models.ClassFarmacia> ClassFarmacia { get; set; } = default!;
    }
}
