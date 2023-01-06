using fakestoreapi.application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fakestoreapi.application.Handlers
{
    public class DeletePeopleByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeletePeopleByIdCommandHandler : IRequestHandler<DeletePeopleByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeletePeopleByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeletePeopleByIdCommand command, CancellationToken cancellationToken)
            {
                var People = await _context.Peoples.Where(a => a.PeopleID == command.Id).FirstOrDefaultAsync();
                if (People == null) return default;
                _context.Peoples.Remove(People);
                await _context.SaveChangesAsync(cancellationToken);
                return People.PeopleID;
            }
        }
    }
}