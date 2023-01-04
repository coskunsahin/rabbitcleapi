using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.application.Queries;
using fakestoreapi.rabbit;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace fakestoreapi.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProsessController : ControllerBase
    {


        private readonly IApplicationDbContext _context;
      
        private readonly IRabitMQProducer _rabitMQProducer;
        public ProsessController(IApplicationDbContext context,IRabitMQProducer rabitMQProducer)
        {
            _context = context;

            _rabitMQProducer = rabitMQProducer;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetProses()
        {
            
           
            var pro = _context.Contacts.Include(c => c.People).Select(y => new {Phone=y.Phone,Name=y.People.Name}).Count();
         
            //Console.WriteLine("Total No of Name = " + pro);
            //Console.WriteLine("Total No of Phone = " + pro);
            //Console.ReadKey();
            //var pro = _context.Contacts.Include(c => c.People).GroupBy(x => new { x.People.Name, x.People.PeopleID, x.Location, x.Phone })
            //     .Select(x => new
            //     {
            //         //x.Key.Name,
            //         // x.Key.Phone,
            //         //total = x.Select(y => y.PeopleID).Count(),
            //         loc = x.Select(y => y.People.Name).Count(),

            //         x.Key.Location,
            //     }


            //     ).OrderBy(y => y.Location).ThenByDescending(x => x.Location).ToList();

            _rabitMQProducer.SendProductMessage(pro);

            return Ok(pro) ;
        }
    }
}
