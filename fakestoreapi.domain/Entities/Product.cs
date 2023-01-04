using fakestoreapi.domain.Common;
using fakestoreapi.domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.domain.Entities
{
    public class Product: AuditEntity
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public  int  Quanty { get; set; }
        public double Price { get; set; }

        public string Category { get; set; }
        public string Image { get; set; }
        public Rating Rating { get; set; }
        public People People { get; set; }

    }
}
