using fakestoreapi.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fakestoreapi;
namespace TestServices
{
    public class People
    {
        public int PeopleID { get; set; }
        public string? Name { get; set; }

        public string? LastName { get; set; }

        public string? Company { get; set; }


        public DateTime ReportTime { get; set; }
        public List<Contact>? Contacts { get; set; }

    }
}
