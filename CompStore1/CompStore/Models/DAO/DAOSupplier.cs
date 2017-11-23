using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAOSupplier
    {
        Entities entities = new Entities();

        public IEnumerable<Supplier> GetAllSupplier()
        {
            return entities.Supplier.Select(n => n);
        }

        public Supplier GetSupplier(int id)
        {
            return entities.Supplier.Where(n => n.Id == id).First();
        }

        public bool AddSupplier(Supplier supplier)
        {
            try
            {
                entities.Supplier.Add(supplier);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateSupplier(Supplier s)
        {
            try
            {
                var Entity = entities.Supplier.FirstOrDefault(x => x.Id == s.Id);
                Entity.Name = s.Name;
                Entity.Adress = s.Adress;
                Entity.Phone = s.Phone;
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteSupplier(int id)
        {
            try
            {
                Supplier s = GetSupplier(id);
                entities.Supplier.Remove(s);
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