using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.rabbit;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fakestoreapi.application.Queries
{
    public class Ping : IRequest<string> { }
    public class PingHandler : IRequestHandler<Ping, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;
        public string Handle(Ping request)
        {
            return "Pong";
        }
        public PingHandler(IApplicationDbContext context, IRabitMQProducer rabitMQProducer
)
        {
            _rabitMQProducer= rabitMQProducer;

            _context = context;
        }

        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            var pro = _context.Contacts.Include(c => c.People).Select(y => new { Phone = y.Phone, Name = y.People.Name }).Count().ToString();
            _rabitMQProducer.SendProductMessage(pro);
            return Task.FromResult(pro);
        }
    }
     
   
}
