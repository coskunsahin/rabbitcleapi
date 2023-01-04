using fakestoreapi.application.Common.Interfaces;

using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels;
using RabbitMQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

using fakestoreapi.api.Services;
using fakestoreapi.rabbit;


namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SistemController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;
      //  private readonly IRabitMQProducer _rabitMQProducer;
        private long lon;
        public SistemController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }

        [HttpGet("{lon}")]
        public async Task<IActionResult> GetById(long lon)
        {
            return Ok(await Mediator.Send(new GetSistemQuery { lon = lon }));
        }

    }
}
