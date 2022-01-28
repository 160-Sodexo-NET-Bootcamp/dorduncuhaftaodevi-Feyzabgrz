using Entities.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ExchangeDbContext : DbContext, IExchangeDbContext
    {

        public ExchangeDbContext(DbContextOptions<ExchangeDbContext> options) : base(options)
        {
        }
        public DbSet<Exchange> Exchange { get; set; }

        public override int SaveChanges()
        {
          
            return base.SaveChanges();
        }



    }
}
