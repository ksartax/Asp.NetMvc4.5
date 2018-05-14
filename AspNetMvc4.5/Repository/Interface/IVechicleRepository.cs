using AspNetMvc4._5.Models;
using AspNetMvc4._5.ModelViews;
using System.Collections.Generic;

namespace AspNetMvc4._5.Repository.Interface
{
    public interface IVechicleRepository
    {
        List<Vachicle> GetList();
        bool Add(VachicleCreateModel vachicle);
        bool Update(int id, VachicleUpdateModel vachicle);
        Vachicle Get(int id);
        bool Delete(Vachicle vachicle);
    }
}
