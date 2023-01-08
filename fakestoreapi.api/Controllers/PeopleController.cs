using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.application.Fakestoreapi;
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

using System;
using fakestoreapi.application.Delete;

namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PeopleController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;
      
        public PeopleController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePeopleCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllPeopleQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetPeoplesByIdQuery { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeletePeopleByIdCommand { Id = id }));
        }

    }
}
