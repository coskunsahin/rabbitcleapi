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
    public class DeleteContactByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteContactByIdCommandHandler : IRequestHandler<DeleteContactByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteContactByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteContactByIdCommand command, CancellationToken cancellationToken)
            {
                var Contact = await _context.Contacts.Where(a => a.People.PeopleID == command.Id).Include(a => a.People).FirstOrDefaultAsync();
                if (Contact == null) return default;
                _context.Contacts.Remove(Contact);
                await _context.SaveChangesAsync(cancellationToken);
                return Contact.Id;
                //}
            }
        }
    }
}