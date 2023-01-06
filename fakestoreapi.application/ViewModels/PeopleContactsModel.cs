using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.application.ViewModels
{
    public class PeopleContactsModel
    {
        public int peopleid;

        public int? PeopleId { get; set; }
        public string Name { get; set; }

        public int CountContact { get; set; }

        
        public int Id { get; set; }

        public int? Phone { get; set; }
        public int? Localtion { get; set; }
        public int Count { get; set; }
    }

}

