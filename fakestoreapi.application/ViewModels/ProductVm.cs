using fakestoreapi.domain.Common;
using fakestoreapi.domain.Entities;
using fakestoreapi.domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.application.ViewModels
{
    public class ProductVm
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Quanty { get; set; }
        public double Price { get; set; }

        public string Category { get; set; }
        public string Image { get; set; }
        public Rating Rating
        {
            get
            {
                return (Rating)(Price * Quanty);
            }
        }
    }

}

