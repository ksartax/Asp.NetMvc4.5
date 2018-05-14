using AspNetMvc4._5.Models;
using System.Collections.Generic;

namespace AspNetMvc4._5.Repository.Interface
{
    public interface ICategoryRepository
    {
        List<Category> GetList();
        bool Add(Category category);
        bool Update(Category category);
        Category Get(int id);
        bool Delete(Category category);
    }
}
