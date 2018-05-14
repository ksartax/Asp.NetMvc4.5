using AspNetMvc4._5.Repository.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using AspNetMvc4._5.Models;
using AspNetMvc4._5.ModelViews;
using System;

namespace AspNetMvc4._5.Repository
{
    public class VechicleRepository : IVechicleRepository
    {
        private readonly Context.ApplicationDbContext _applicationDbContext;

        public VechicleRepository()
        {
            _applicationDbContext = new Context.ApplicationDbContext();
        }

        public bool Add(VachicleCreateModel vachicle)
        {
            var _vachicle = new Vachicle(vachicle);

            if (vachicle.Categories != null)
            {
                foreach (var id in vachicle.Categories)
                {
                    var _ver = _applicationDbContext.Categories.FirstOrDefault(c => c.ID == id);
                    if (_ver == null)
                    {
                        throw new ApplicationException();
                    }

                    _vachicle.Categories.Add(_ver);
                }
            }

            _applicationDbContext.Vechicles.Add(_vachicle);

            return _applicationDbContext.SaveChanges() > 0;
        }

        public bool Delete(Vachicle vachicle)
        {
            _applicationDbContext.Vechicles.Remove(vachicle);

            return _applicationDbContext.SaveChanges() > 0;
        }

        public Vachicle Get(int id)
        {
            return _applicationDbContext.Vechicles.FirstOrDefault(t => t.ID == id);
        }

        public List<Vachicle> GetList()
        {
            return _applicationDbContext.Vechicles.ToList();
        }

        public bool Update(int id, VachicleUpdateModel vachicle)
        {
            var _vachicle = Get(id);
            if (_vachicle == null)
            {
                throw new ApplicationException();
            }

            _vachicle.Update(vachicle);

            if (vachicle.Categories != null)
            {
                foreach (var _id in vachicle.Categories)
                {
                    if (_vachicle.Categories.Any(c => c.ID == _id))
                    {
                        continue;
                    }

                    var _ver = _applicationDbContext.Categories.FirstOrDefault(c => c.ID == _id);
                    if (_ver == null)
                    {
                        throw new ApplicationException();
                    }

                    _vachicle.Categories.Add(_ver);
                }
            }

            _applicationDbContext.Entry(_vachicle).State = EntityState.Modified;

            return _applicationDbContext.SaveChanges() > 0;
        }
    }
}