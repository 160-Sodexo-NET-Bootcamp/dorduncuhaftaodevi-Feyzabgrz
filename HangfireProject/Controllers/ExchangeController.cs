using AutoMapper;
using Data.Dtos;
using Data.UnitOfWork;
using Entities.DataModel;
using Hangfire;
using HangfireProject.Jobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HangfireProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        private readonly ILogger<ExchangeController> logger;
        IMapper mapper;

        public ExchangeController(ILogger<ExchangeController> logger, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpPost]
        public void RunJobs()
        {
            ExchangeRecurringJob jobMachine = new ExchangeRecurringJob(unitOfWork);
            RecurringJob.AddOrUpdate(() => jobMachine.StartAddJob(), "*/15 * * * *" , TimeZoneInfo.Local);
            RecurringJob.AddOrUpdate(() => jobMachine.StartDailyJob(), "0 18 * * * " , TimeZoneInfo.Local);
           
        }
    }
}
