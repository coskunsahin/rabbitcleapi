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
using System.ComponentModel.Design;
using fakestoreapi.domain.Entities.Domain.Entities;
using fakestoreapi.rabbit;

namespace fakestoreapi.application.Handlers
{
    public class GetSistemQueryHandler : IRequestHandler<GetSistemQuery, IList<PeopleVM>>
    {
        private readonly IRabitMQProducer _rabitMQProducer;


        private readonly IApplicationDbContext _context;


        public GetSistemQueryHandler(IApplicationDbContext context, IRabitMQProducer rabitMQProducer)
        {
            _context = context;
            _rabitMQProducer= rabitMQProducer;
        }

        public long lon { get;  set; }

        public async Task<IList<PeopleVM>> Handle(GetSistemQuery request, CancellationToken cancellationToken)
        {
            

            var peoplet = await _context.Peoples.Include(i => i.Contacts)
                .Where(i => i.CreatedBy == request.User).ToListAsync();
          
            var vm = peoplet.Select(i => new PeopleVM
            {

                Name = i.Name,
                PeopleID = i.PeopleID,
                LastName = i.LastName,
                Company = i.Company,
                Contacts = i.Contacts.Select(k => new ContactVM
                {


                    Phone = k.Phone,
                    Location = k.Location,
                    Email = k.Email,
                    Addrees = k.Addrees,




                }).Where(a => a.Location == request.lon).OrderByDescending(s => s.Location).ToList()

            }).ToList();

            _rabitMQProducer.SendProductMessage(vm);

            return vm;
        }
    }

}