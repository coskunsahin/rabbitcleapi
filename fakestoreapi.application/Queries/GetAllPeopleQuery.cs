
using fakestoreapi.application.Common.Interfaces;
using fakestoreapi.domain.Entities;
using fakestoreapi.domain.Entities.Domain.Entities;
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
    public class GetAllPeopleQuery : IRequest<IEnumerable<People>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllPeopleQuery, IEnumerable<People>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<People>> Handle(GetAllPeopleQuery query, CancellationToken cancellationToken)
            {
                var people = await _context.Peoples.ToListAsync();
                if (people == null)
                {
                    return null;
                }
                return people.AsReadOnly();
            }

        }
    }
}
