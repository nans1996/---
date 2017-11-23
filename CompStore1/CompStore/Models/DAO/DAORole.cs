using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAORole
    {
        private Entities entities = new Entities();

        public IEnumerable<AspNetRoles> GetAllRoles()
        {
            return entities.AspNetRoles.Select(n => n);
        }

        public AspNetRoles GetRole(string id)
        {
            return entities.AspNetRoles.Where(n => n.Id == id).First();
        }

        public bool UpdateRoles(string id, AspNetRoles st)
        {
            try
            {
                var Entity = entities.AspNetUsers.FirstOrDefault(n => n.Id == id);
                var EntityRoles = entities.AspNetRoles.FirstOrDefault(n => n.Name == st.Name);
                Entity.AspNetRoles.Add(EntityRoles);
                entities.SaveChanges();

            }
            catch
            {
                return false;
            }
            return true;

        }

    }
}