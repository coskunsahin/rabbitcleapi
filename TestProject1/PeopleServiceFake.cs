
using fakestoreapi.application.Queries;
using fakestoreapi.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServices
{
    
    public class PeopleServiceFake : GetAllPeopleQuery
    {
        private readonly List<People> _people;

        public PeopleServiceFake()
        {
            _people = new List<People>()
            {
                new People() { PeopleID = 1,LastName="hallit",Company="csd",
                    Name = "Orcun"},
                new People() { PeopleID = 1,LastName="sahin",Company="csd",
                    Name = "kasım"},
               new People() { PeopleID = 1,LastName="sahin",Company="csd",
                    Name = "nigmet"},
            };
        }

        public IEnumerable<People> GetAllItems()
        {
            return _people;
        }

        public People Add(People newPeople)
        {
            newPeople.PeopleID = newPeople.PeopleID;
            _people.Add(newPeople);
            return newPeople;
        }

        public People GetById(int id)
        {
            return _people.Where(a => a.PeopleID == id)
                .FirstOrDefault();
        }

        public void Remove(int id)
        {
            var existing = _people.First(a => a.PeopleID == id);
            _people.Remove(existing);
        }
    }
}


