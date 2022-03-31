#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NRGi_aspirant_opgave.Models;

namespace NRGi_aspirant_opgave.Data
{
    public class ConditionReportsContext : DbContext
    {
        public ConditionReportsContext (DbContextOptions<ConditionReportsContext> options)
            : base(options)
        {
        }

        public DbSet<NRGi_aspirant_opgave.Models.ConditionReport> ConditionReport { get; set; }
    }
}
