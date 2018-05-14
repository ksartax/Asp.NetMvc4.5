using AspNetMvc4._5.ModelViews;
using System.Collections.Generic;

namespace AspNetMvc4._5.Services.Interface
{
    public interface IVechicleService
    {
        List<VachicleViewModel> GetListView();
        void Add(VachicleCreateModel vechicle);
        void Update(int id, VachicleUpdateModel vechicle);
        VachicleViewModel GetView(int id);
        VachicleUpdateModel GetEditView(int id);
        void Delete(int id);
    }
}
