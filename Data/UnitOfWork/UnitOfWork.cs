using AutoMapper;
using Data.Context;
using Data.ExchangeRepo;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration1;
        private readonly ExchangeDbContext context;
        private readonly IMapper mapper;
        
        public IExchangeRepository Exchange { get; private set; }

        public UnitOfWork(ExchangeDbContext context, ILoggerFactory loggerFactory, IConfiguration configuration, IMapper mapper)
        {
            this.context = context;
            this.logger = loggerFactory.CreateLogger("patika");
            this.mapper = mapper;


            Exchange = new ExchangeRepository(context, logger, mapper);

        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
