using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.domain.Entities
{
   
    using fakestoreapi.domain.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Domain.Entities
    {
        public class People : AuditEntity
        {
           

            //[Table(Contact)]
            public People()
            {
                this.Contacts = new List<Contact>();
            }
            [Key]
            public int PeopleID { get; set; }
            public string Name { get; set; }

            public string LastName { get; set; }

            public string Company { get; set; }


            public DateTime ReportTime { get; set; }
            public List<Contact> Contacts { get; set; }

            
        }
    }
}
