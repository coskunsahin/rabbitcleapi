﻿using fakestoreapi.application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.application.Queries
{
  
    public class GetPeopleAllQuery : IRequest<IList<PeopleVM>>
    {
        public string User { get; set; }
    }
}
