
using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.domain.Entities;
using fakestoreapi.domain.Entities.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fakestoreapi.application.Queries
{
    public class GetPeoplesByIdQuery : IRequest<People>
    {
        public int Id { get; set; }

        public class GetPeoplesByIdQueryHandler : IRequestHandler<GetPeoplesByIdQuery, People>
        {
            private readonly IApplicationDbContext _context;
            public GetPeoplesByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<People> Handle(GetPeoplesByIdQuery query, CancellationToken cancellationToken)
            {
                var People = _context.Peoples.Where(a => a.PeopleID == query.Id).FirstOrDefault();
                if (People == null) return null;
                return People;
            }

        }
    }
}

