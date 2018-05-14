using AspNetMvc4._5.Services.Interface;
using System.Collections.Generic;
using AspNetMvc4._5.Repository.Interface;
using AspNetMvc4._5.Repository;
using System;
using AspNetMvc4._5.Models;

namespace AspNetMvc4._5.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _typesRepository = new CategoryRepository();

        public void Add(CategoryCreateModel category)
        {
            if (!_typesRepository.Add(new Category(category)))
            {
                throw new ApplicationException();
            }
        }

        public void Delete(int id)
        {
            var category = _typesRepository.Get(id);
            if (category == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            if (!_typesRepository.Delete(category))
            {
                throw new ApplicationException("Błąd, blad zapisu");
            }
        }

        public CategoryUpdateModel GetEditView(int id)
        {
            var category = _typesRepository.Get(id);
            if (category == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            return new CategoryUpdateModel(category);
        }

        public List<CategoryViewModel> GetListView()
        {
            List<CategoryViewModel> _mappedTypes = new List<CategoryViewModel>();

            _typesRepository.GetList().ForEach(t => _mappedTypes.Add(new CategoryViewModel(t)));

            return _mappedTypes;
        }

        public CategoryViewModel GetView(int id)
        {
            var category = _typesRepository.Get(id);
            if (category == null)
            {
                throw new ApplicationException("Błąd, brak encji");
            }

            return new CategoryViewModel(category);
        }

        public void Update(int id, CategoryUpdateModel category)
        {
            var _category = _typesRepository.Get(id);
            if (_category == null)
            {
                throw new ApplicationException("Błąd, blad edycji");
            }

            _category.Update(category);

            if (!_typesRepository.Update(_category))
            {
                throw new ApplicationException();
            }
        }
    }
}