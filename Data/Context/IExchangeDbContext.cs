using Entities.DataModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public  interface IExchangeDbContext
    {
         DbSet<Exchange> Exchange { get; set; }


        int SaveChanges();
    }
}
