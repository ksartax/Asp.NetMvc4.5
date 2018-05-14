using AspNetMvc4._5.Services.Interface;
using System.Collections.Generic;
using AspNetMvc4._5.ModelViews;
using AspNetMvc4._5.Repository.Interface;
using AspNetMvc4._5.Repository;
using System;

namespace AspNetMvc4._5.Services
{
    public class TypesService : ITypesService
    {
        private readonly ITypesRepository _typesRepository = new TypesRepository();

        public void Add(TypesCreateModel type)
        {
            if (!_typesRepository.Add(new Models.Type(type)))
            {
                throw new ApplicationException();
            }
        }

        public void Delete(int id)
        {
            var type = _typesRepository.Get(id);
            if (type == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            if (!_typesRepository.Delete(type))
            {
                throw new ApplicationException("Błąd, blad zapisu");
            }
        }

        public TypesUpdateModel GetEditView(int id)
        {
            var type = _typesRepository.Get(id);
            if (type == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            return new TypesUpdateModel(type);
        }

        public List<TypesViewModel> GetListView()
        {
            List<TypesViewModel> _mappedTypes = new List<TypesViewModel>();

            _typesRepository.GetList().ForEach(t => _mappedTypes.Add(new TypesViewModel(t)));

            return _mappedTypes;
        }

        public TypesViewModel GetView(int id)
        {
            var type = _typesRepository.Get(id);
            if (type == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            return new TypesViewModel(type);
        }

        public void Update(int id, TypesUpdateModel type)
        {
            var _type = _typesRepository.Get(id);
            if (_type == null)
            {
                throw new ApplicationException("Błąd, blad edycji");
            }

            _type.Update(type);

            if (!_typesRepository.Update(_type))
            {
                throw new ApplicationException();
            }
        }
    }
}