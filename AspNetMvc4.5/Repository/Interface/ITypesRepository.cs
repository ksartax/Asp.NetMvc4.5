using System.Collections.Generic;

namespace AspNetMvc4._5.Repository.Interface
{
    public interface ITypesRepository
    {
        List<Models.Type> GetList();
        bool Add(Models.Type type);
        bool Update(Models.Type type);
        Models.Type Get(int id);
        bool Delete(Models.Type type);
    }
}
