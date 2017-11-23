using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAOProduct
    {
        Entities entities = new Entities();

        public IEnumerable<Product> GetAllProducts()
        {
            return entities.Product.Select(n => n);
        }

        public Product GetProduct(int id)
        {
            return entities.Product.Where(n => n.Id == id).First();
        }

        public bool AddProduct(Product product)
        {
            try
            {
                entities.Product.Add(product);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool UpdateProduct(Product p)
        {
            try
            {
                var Entity = entities.Product.FirstOrDefault(x => x.Id == p.Id);
                Entity.Name = p.Name;
                Entity.Id_category = p.Id_category;
                Entity.Brand = p.Brand;
                Entity.Id_supplier = p.Id_supplier;
                Entity.Country = p.Country;
                Entity.Number = p.Number;
                Entity.Price = p.Price;
                Entity.Accounting_date = p.Accounting_date;
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }

            return true;
        }

        public bool DeleteProduct(int id)
        {
            try
            {
                Product pr = GetProduct(id);
                entities.Product.Remove(pr);
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