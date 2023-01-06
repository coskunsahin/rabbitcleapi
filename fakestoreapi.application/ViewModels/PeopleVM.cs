using fakestoreapi.application.ViewModels.Application.Invoices.ViewModels;
using fakestoreapi.domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.application.ViewModels
{
    public class PeopleVM
    {


        public PeopleVM()
        {
            this.Contacts = new List<ContactVM>();
        }

        public int PeopleID { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }



        public DateTime ReportTime { get; set; }
        public List<ContactVM> Contacts { get; set; }
        public object GroupId { get; internal set; }
    }
}
