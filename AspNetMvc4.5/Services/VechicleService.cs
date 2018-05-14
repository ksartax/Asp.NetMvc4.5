using AspNetMvc4._5.Services.Interface;
using System.Collections.Generic;
using AspNetMvc4._5.Repository.Interface;
using AspNetMvc4._5.Repository;
using System;
using AspNetMvc4._5.ModelViews;

namespace AspNetMvc4._5.Services
{
    public class VechicleService : IVechicleService
    {
        private readonly IVechicleRepository _vechicleRepository = new VechicleRepository();

        public void Add(VachicleCreateModel vechicle)
        {
            if (!_vechicleRepository.Add(vechicle))
            {
                throw new ApplicationException();
            }
        }

        public void Delete(int id)
        {
            var vechicle = _vechicleRepository.Get(id);
            if (vechicle == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            if (!_vechicleRepository.Delete(vechicle))
            {
                throw new ApplicationException("Błąd, blad zapisu");
            }
        }

        public VachicleUpdateModel GetEditView(int id)
        {
            var vechicle = _vechicleRepository.Get(id);
            if (vechicle == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            return new VachicleUpdateModel(vechicle);
        }

        public List<VachicleViewModel> GetListView()
        {
            List<VachicleViewModel> _mappedTypes = new List<VachicleViewModel>();

            _vechicleRepository.GetList().ForEach(t => _mappedTypes.Add(new VachicleViewModel(t)));

            return _mappedTypes;
        }

        public VachicleViewModel GetView(int id)
        {
            var vechicle = _vechicleRepository.Get(id);
            if (vechicle == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            return new VachicleViewModel(vechicle);
        }

        public void Update(int id, VachicleUpdateModel vachicle)
        {
            if (!_vechicleRepository.Update(id, vachicle))
            {
                throw new ApplicationException();
            }
        }
    }
}