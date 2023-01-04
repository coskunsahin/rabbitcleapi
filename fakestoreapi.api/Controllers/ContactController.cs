using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fakestoreapi.application.Common.Interfaces;
//using fakestoreapi.application.Fakestoreapi;
using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels;
using RabbitMQ;
using Microsoft.AspNetCore.Authorization;

using System.Collections.Generic;
using System.Threading.Tasks;

using fakestoreapi.api.Services;
using fakestoreapi.rabbit;
using fakestoreapi.application.Handlers;

namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ApiController
    {
        private readonly ICurrentUserService _currentUserService;

        public ContactController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;

        }
        [HttpGet("{lon}")]
        public async Task<IActionResult> GetLocal(long lon)
        {
            return Ok(await Mediator.Send(new GetSistemQuery { lon = lon }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> ContactDelete(int id)
        {

            return Ok(await Mediator.Send(new DeleteContactByIdCommand { Id = id }));



        }
        [HttpGet]
        public async Task<IList<PeopleVM>> GetPeoples()
        {
            return await Mediator.Send(new GetAnaQuery());
        }


    }
}
