﻿using fakestoreapi.application.Common.Interfaces;
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

namespace fakestoreapi.application.Queries
{
    public class GetSistem : IRequestHandler<GetUserPeopleQuery, IList<PeopleVM>>
    {


        private readonly IApplicationDbContext _context;

        private readonly IRabitMQProducer _rabitMQProducer;

        public GetSistem(IApplicationDbContext context,IRabitMQProducer rabitMQProducer)
        {
            _context = context;
            _rabitMQProducer= rabitMQProducer;
        }

        public async Task<IList<PeopleVM>> Handle(GetUserPeopleQuery request, CancellationToken cancellationToken)
        {
           

            var peoplet = await _context.Peoples.Include(i => i.Contacts)
               .ToListAsync();

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

            _rabitMQProducer.SendProductMessage(vm);
            return vm;
        }
    }

}

