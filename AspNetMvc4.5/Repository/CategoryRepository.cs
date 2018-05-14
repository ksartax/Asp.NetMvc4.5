using AspNetMvc4._5.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AspNetMvc4._5.Models;

namespace AspNetMvc4._5.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly Context.ApplicationDbContext _applicationDbContext;

        public CategoryRepository()
        {
            _applicationDbContext = new Context.ApplicationDbContext();
        }

        public bool Add(Category category)
        {
            _applicationDbContext.Categories.Add(category);

            return _applicationDbContext.SaveChanges() > 0;
        }

        public bool Delete(Category category)
        {
            _applicationDbContext.Categories.Remove(category);

            return _applicationDbContext.SaveChanges() > 0;
        }

        public Category Get(int id)
        {
            return _applicationDbContext.Categories.FirstOrDefault(t => t.ID == id);
        }

        public List<Category> GetList()
        {
            return _applicationDbContext.Categories.ToList();
        }

        public bool Update(Category category)
        {
            _applicationDbContext.Entry(category).State = EntityState.Modified;

            return _applicationDbContext.SaveChanges() > 0;
        }
    }
}