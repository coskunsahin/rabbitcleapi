using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.application.ViewModels
{
   
    using System;

    namespace Application.Invoices.ViewModels
    {
        public class ContactVM
        {
            public int Id { get; set; }
            public Guid Uuid { get; set; }

            public int PeopleID { get; set; }
            public int Phone { get; set; }
            public string Email { get; set; }
            public string Addrees { get; set; }
            public long Location { get; set; }
            public string Info { get; set; }
            public int Count { get; internal set; }
            public object GroupId { get; internal set; }
        }
    }
}
