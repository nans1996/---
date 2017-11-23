using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAOSelling
    {

        Entities entities = new Entities();

        public IEnumerable<Selling> GetAllSelling()
        {
            return entities.Selling.Select(n => n);
        }

        public Selling GetSelling(int id)
        {
            return entities.Selling.Where(n => n.Id == id).First();
        }

        public bool AddSelling(Selling selling)
        {
            try
            {

                entities.Selling.Add(selling);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateSelling(Selling s)
        {
            try
            {
                var Entity = entities.Selling.FirstOrDefault(x => x.Id == s.Id);
                Entity.Id_product = s.Id_product;
                Entity.Id_seller = s.Id_seller;
                Entity.Number = s.Number;
                Entity.Price = s.Price;
                Entity.datetime = s.datetime;
                Entity.Status = s.Status;

                entities.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteSelling(int id)
        {
            try
            {
                Selling pr = GetSelling(id);
                entities.Selling.Remove(pr);
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