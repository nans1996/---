using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAOrole
    {
        private Entities _entities = new Entities();

        public IEnumerable<AspNetRoles> GetAllRole()
        {
            return _entities.AspNetRoles.Select(n => n);
        }
    }

}
