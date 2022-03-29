#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NRGi_aspirant_opgave.Models;

namespace NRGi_aspirant_opgave.Data
{
    public class NRGi_aspirant_opgaveContext : DbContext
    {
        public NRGi_aspirant_opgaveContext (DbContextOptions<NRGi_aspirant_opgaveContext> options)
            : base(options)
        {
        }

        public DbSet<NRGi_aspirant_opgave.Models.Property> Property { get; set; } = null;

        public DbSet<NRGi_aspirant_opgave.Models.ConditionReport> ConditionReport { get; set; } = null;
    }
}
