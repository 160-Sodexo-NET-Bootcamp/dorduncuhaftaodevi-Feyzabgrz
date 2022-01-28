using AutoMapper;
using Data.Context;
using Data.Generic;
using Entities.DataModel;
using Infrastructure.Result;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.ExchangeRepo
{
    public  class ExchangeRepository : GenericRepository<Exchange> , IExchangeRepository
    {
        IMapper mapper;
        public ExchangeRepository(ExchangeDbContext context, ILogger logger, IMapper mapper) : base(context, logger)
        {
            this.mapper = mapper;
        }


        public IEnumerable<Exchange> Where(Expression<Func<Exchange, bool>> where)
        {
            return base.Where(where);
        }

        public async Task<Result<Exchange>> Add(Exchange entity)
        {
            return await base.Add(entity);
        }

        public async Task<Result> Delete(long id)
        {
            return await base.Delete(id);
        }

        public Task<Result<List<Exchange>>> GetAll()
        {
            return base.GetAll();
        }


        public Task<Result<Exchange>> Update(Exchange entity)
        {
            return base.Update(entity);

        }
    }
}
