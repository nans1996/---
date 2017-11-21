using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
    }
}