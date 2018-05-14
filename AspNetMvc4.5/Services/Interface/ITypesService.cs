using AspNetMvc4._5.ModelViews;
using System.Collections.Generic;

namespace AspNetMvc4._5.Services.Interface
{
    public interface ITypesService
    {
        List<TypesViewModel> GetListView();
        void Add(TypesCreateModel type);
        void Update(int id, TypesUpdateModel type);
        TypesViewModel GetView(int id);
        TypesUpdateModel GetEditView(int id);
        void Delete(int id);
    }
}
