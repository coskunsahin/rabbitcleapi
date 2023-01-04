using fakestoreapi.application.ViewModels;
using fakestoreapi.domain.Entities;
using fakestoreapi.domain.Entities.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fakestoreapi.application.Common.Interfaces
{
    public interface IPersonLocalService
    {


        public IList<People>  GetPeoples();
    }
}
