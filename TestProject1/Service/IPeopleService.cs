using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fakestoreapi;
using fakestoreapi.domain.Entities;

namespace TestServices
{    
    
    
    public interface IPeopleServiceFAKE
    {
        IEnumerable<People> GetAllIPeople();
        People Add(People newPeople);
        People GetById(People PeopleID);
        void Remove(People peopleID);
    }
}
