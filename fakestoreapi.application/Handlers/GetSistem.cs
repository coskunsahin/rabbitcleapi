using fakestoreapi.application.Common.Interfaces;
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
using fakestoreapi.application.Queries;

namespace fakestoreapi.application.Handlers
{
    public class GetSistem : IRequestHandler<GetUserPeopleQuery, IList<PeopleVM>>
    {


        private readonly IApplicationDbContext _context;


        public GetSistem(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<PeopleVM>> Handle(GetUserPeopleQuery request, CancellationToken cancellationToken)
        {


            var peoplet = await _context.Peoples.Include(i => i.Contacts)
               .ToListAsync();
            //  var tr=_context.Contacts.Where(a => a.Location == request.lon).FirstOrDefault();
            var vm = peoplet.Select(i => new PeopleVM
            {

                Name = i.Name,
                ReportTime = i.ReportTime,
                PeopleID = i.PeopleID,
                LastName = i.LastName,
                Company = i.Company,
                Contacts = i.Contacts.Select(k => new ContactVM
                {
                    Uuid = k.Uuid,
                    Phone = k.Phone,
                    Location = k.Location,
                    Email = k.Email,
                    Addrees = k.Addrees,




                }).Where(a => a.Location == request.lon).OrderByDescending(s => s.Location).ToList()

            }).ToList();
             

            return vm;
        }
    }

}

