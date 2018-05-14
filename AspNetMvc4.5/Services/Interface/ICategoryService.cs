using AspNetMvc4._5.Models;
using System.Collections.Generic;

namespace AspNetMvc4._5.Services.Interface
{
    public interface ICategoryService
    {
        List<CategoryViewModel> GetListView();
        void Add(CategoryCreateModel category);
        void Update(int id, CategoryUpdateModel category);
        CategoryViewModel GetView(int id);
        CategoryUpdateModel GetEditView(int id);
        void Delete(int id);
    }
}
