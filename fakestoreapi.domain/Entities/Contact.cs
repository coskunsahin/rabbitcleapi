
using fakestoreapi.domain.Entities.Domain.Entities;
using fakestoreapi.domain.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.domain.Entities
{
    public class Contact : AuditEntity
    {
        [Required]

        [Key]

        public int Id { get; set; }
        public Guid Uuid { get; set; }

        public int PeopleID { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string Addrees { get; set; }
        public long Location { get; set; }
        public string Info { get; set; }
        public People People { get; set; }
    }
}