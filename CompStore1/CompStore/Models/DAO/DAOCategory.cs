using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompStore.Models.DAO
{
    public class DAOCategory
    {
        private Entities entities = new Entities();

        public IEnumerable<Category> GetAllCategoryes()
        {
            return entities.Category.Select(n => n);
        }


        public bool AddCategory(Category category)
        {
            try
            {
                entities.Category.Add(category);
                entities.SaveChanges();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void UpdateCategory(Category category)
        {
            var Entity = entities.Category.FirstOrDefault(x => x.Id == category.Id);
            Entity.Name = category.Name;
            entities.SaveChanges();
        }

        public Category GetCategory(int id)
        {
            return entities.Category.Where(n => n.Id == id).First();
        }

        public void DeleteCategory(int id)
        {
            Category orCat = GetCategory(id);
            entities.Category.Remove(orCat);
            entities.SaveChanges();

        }
    }
}