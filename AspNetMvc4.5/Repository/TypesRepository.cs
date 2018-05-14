using AspNetMvc4._5.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace AspNetMvc4._5.Repository
{
    public class TypesRepository : ITypesRepository
    {
        private readonly Context.ApplicationDbContext _applicationDbContext;

        public TypesRepository()
        {
            _applicationDbContext = new Context.ApplicationDbContext();
        }

        public bool Add(Models.Type type)
        {
            _applicationDbContext.Types.Add(type);

            return _applicationDbContext.SaveChanges() > 0;
        }

        public bool Delete(Models.Type type)
        {
            _applicationDbContext.Entry(type).State = EntityState.Deleted;

            _applicationDbContext.Types.Remove(type);

            return _applicationDbContext.SaveChanges() > 0;
        }

        public Models.Type Get(int id)
        {
            return _applicationDbContext.Types.FirstOrDefault(t => t.ID == id);
        }

        public List<Models.Type> GetList()
        {
            return _applicationDbContext.Types.ToList();
        }

        public bool Update(Models.Type type)
        {
            _applicationDbContext.Entry(type).State = EntityState.Modified;

            return _applicationDbContext.SaveChanges() > 0;
        }
    }
}