using Microsoft.EntityFrameworkCore;
using SkandinavAdat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkandinavAdat.Data
{
    public class SkandinavAdatContext : DbContext
    {
        public DbSet<LottoSzam> LottoSzamok { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;database=LottoSzamok7;Trusted_Connection=true");
        }
    }
}
