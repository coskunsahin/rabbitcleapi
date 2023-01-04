using fakestoreapi.application.ViewModels;
using fakestoreapi.application.ViewModels.Application.Invoices.ViewModels;
using fakestoreapi.domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.application.Fakestoreapi
{
    public class CreatePeopleCommand : IRequest<int>
    {
        public CreatePeopleCommand()
        {
            this.Contacts = new List<ContactVM>();
        }


        public string Name { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }


        public DateTime ReportTime { get; set; }
        public IList<ContactVM> Contacts { get; set; }
    }
}