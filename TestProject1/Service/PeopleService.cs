using fakestoreapi.application.ViewModels;
using fakestoreapi.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServices.Service
{
   
    public class PeopleService : IPeopleServiceFAKE
    {
        public People Add(People newPeople) => throw new NotImplementedException();

        public IEnumerable<People> GetAllIPeople() => throw new NotImplementedException();

        public People GetById(People peopleID) => throw new NotImplementedException();

        public void Remove(People peopleID) => throw new NotImplementedException();

      
    }
}
