using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.application.Queries;
using fakestoreapi.application.ViewModels.Application.Invoices.ViewModels;
using fakestoreapi.application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using fakestoreapi.rabbit;

namespace fakestoreapi.application.Handlers
{
    public class GetAnaQueryHandler : IRequestHandler<GetAnaQuery, IList<PeopleVM>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IRabitMQProducer _rabitMQProducer;

        public GetAnaQueryHandler(IApplicationDbContext context, IRabitMQProducer rabitMQProducer
)
        {
            _rabitMQProducer = rabitMQProducer;

            _context = context;
        }

        public async Task<IList<PeopleVM>> Handle(GetAnaQuery request, CancellationToken cancellationToken)
        {
            var peoplet = await _context.Peoples.Include(i => i.Contacts)
                .Where(i => i.CreatedBy == request.User).ToListAsync();
            var vm = peoplet.Select(i => new PeopleVM
            {

                PeopleID = i.PeopleID,
                Name = i.Name,
                LastName = i.Name,
                Company = i.Name,

                Contacts = i.Contacts.Select(k => new ContactVM
                {
                    Phone = k.Phone,
                    Location = k.Location,
                    Addrees = k.Addrees,

                }


                ).OrderByDescending(k => k.Location).ToList()


            }
            ).ToList();

            _rabitMQProducer.SendProductMessage(vm);
            return vm;
        }






    }

}

