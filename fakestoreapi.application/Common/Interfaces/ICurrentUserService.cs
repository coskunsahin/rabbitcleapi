using System;
using System.Collections.Generic;
using System.Text;

namespace fakestoreapi.application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }
    }
}
