using Lab.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Demo.Logic
{
    class CategoriesLogic : BaseLogic, ILogic<Categories>
    {
        public void Delete(int id)
        {
            Categories categoryToDelete = GetOne(id);
            context.Categories.Remove(categoryToDelete);
            context.SaveChanges();
        }

        public List<Categories> GetAll()
        {
            return context.Categories.ToList();
        }

        public Categories GetOne(int id)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryID.Equals(id));
        }

        public Categories Insert(Categories entity)
        {
            int lastId = (from cat in context.Categories
                          orderby cat.CategoryID descending
                          select cat.CategoryID).FirstOrDefault();
            lastId += 1;

            Categories newCategory = context.Categories.Add(entity);
            context.SaveChanges();
            return newCategory;
        }

        public void Update(Categories entity)
        {
            Categories categoryToEdit = GetOne(entity.CategoryID);
            categoryToEdit.CategoryName = entity.CategoryName;
            categoryToEdit.Description = entity.Description;
            context.SaveChanges();
        }
    }
}
