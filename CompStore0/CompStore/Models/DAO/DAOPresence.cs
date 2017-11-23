using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAOPresence
    {
        Entities entities = new Entities();

        public IEnumerable<Presence> GetAllPresence()
        {
            return entities.Presence.Select(n => n);
        }
    }
}