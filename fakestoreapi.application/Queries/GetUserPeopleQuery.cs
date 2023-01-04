using fakestoreapi.application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.application.Queries
{
    public class GetUserPeopleQuery : IRequest<IList<PeopleVM>>
    {
        public string User { get; set; }
        public long lon { get; internal set; }
    }
}