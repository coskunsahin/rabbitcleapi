using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.application.ViewModels;
using fakestoreapi.rabbit;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels.Application.Invoices.ViewModels;

using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace fakestoreapi.application.Queries
{
    public class GetPeopleAllQueryHandler : IRequestHandler<GetPeopleAllQuery, IList<PeopleVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;
        public GetPeopleAllQueryHandler(IApplicationDbContext context, IRabitMQProducer rabitMQProducer
)
        {
            _rabitMQProducer = rabitMQProducer;

            _context = context;
        }

        public async Task<IList<PeopleVM>> Handle(GetPeopleAllQuery request, CancellationToken cancellationToken)
        {

     

            var peoplet = await _context.Peoples.Include(i => i.Contacts)
              .Where(i => i.CreatedBy == request.User).ToListAsync(cancellationToken: cancellationToken);
            var vm = peoplet.Select(i => new PeopleVM
            {

                PeopleID = i.PeopleID,
                Name = i.Name,
                LastName = i.Name,
                Company = i.Name,

               

            }
            ).ToList();

            _rabitMQProducer.SendProductMessage(vm);
            return  vm;
        }
    }
    }
