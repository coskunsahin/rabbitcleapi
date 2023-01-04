using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using fakestoreapi.domain.Entities;
using fakestoreapi.domain.Entities.Domain.Entities;

namespace fakestoreapi.application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<People> Peoples { get; set; }


        DbSet<Contact> Contacts { get; set; }




        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        //IEnumerable<object> Set<T>();
    }
}
