using fakestoreapi.application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using fakestoreapi.application.Fakestoreapi;
using fakestoreapi.domain.Entities;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;
using fakestoreapi.rabbit;
namespace fakestoreapi.application.Handlers
{
    public class CreatePeopleCommandHandler : IRequestHandler<CreatePeopleCommand, int>
    {
        private readonly IApplicationDbContext _context;
        private readonly IRabitMQProducer _rabbitProducer;
        public CreatePeopleCommandHandler(IApplicationDbContext context, IRabitMQProducer rabbitProducer)
        {
            _context = context;
            _rabbitProducer = rabbitProducer;
        }
        public async Task<int> Handle(CreatePeopleCommand request, CancellationToken cancellationToken)
        {
            var entity = new People
            {
                LastName = request.LastName,

                Name = request.Name,
                Company = request.Company,
                ReportTime = request.ReportTime,
                Contacts = request.Contacts.Select(i => new Contact
                {
                    Uuid = Guid.NewGuid(),
                    Phone = i.Phone,
                    Addrees = i.Addrees,
                    Email = i.Email,
                    Location = i.Location,
                    Info = i.Info
                }).ToList()
            };
            _context.Peoples.Add(entity);
            _rabbitProducer.SendProductMessage(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return entity.PeopleID;
        }
    }
}