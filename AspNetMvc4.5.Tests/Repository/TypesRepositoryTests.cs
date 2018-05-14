using AspNetMvc4._5.Context;
using AspNetMvc4._5.Repository.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AspNetMvc4._5.Repository.Tests
{
    [TestClass()]
    public class TypesRepositoryTests
    {
        private readonly ITypesRepository _typesRepository = new TypesRepository();
        private readonly ApplicationDbContext _applicationDbContext = new ApplicationDbContext();

        [TestInitialize]
        public void Init()
        {
            _applicationDbContext.Types.RemoveRange(_applicationDbContext.Types);

            _applicationDbContext.Types.AddRange(new Models.Type[] {
                new Models.Type() { ID = 1, Description = "Sportowe" }
            });

            _applicationDbContext.SaveChanges();
        }

        [TestMethod]
        public void Add_Valid_Test()
        {
            var model = new Models.Type() { ID = 2, Description = "Tirowe" };

            if (_typesRepository.Add(model)) {
                var modelResponde = _applicationDbContext.Types.FirstOrDefault(t => t.ID == model.ID);
                Assert.IsNotNull(modelResponde);
                Assert.AreEqual(modelResponde.Description, model.Description);

                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Add_Not_Valid_Test()
        {
            var model = new Models.Type() { ID = 2, Description = "Tiro" };

            try
            {
                _typesRepository.Add(model);
            }
            catch
            {
                Assert.IsTrue(true);

                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Delete_Test()
        {
            var model = _applicationDbContext.Types.First();

            _typesRepository.Delete(model);

            Assert.IsFalse(_applicationDbContext.Types.Any(t => t.ID == model.ID));
        }

        [TestMethod]
        public void Get_Test()
        {
            var _model = _applicationDbContext.Types.First();
            var model = _typesRepository.Get(_model.ID);

            Assert.AreEqual(_model.ID, model.ID);
            Assert.AreEqual(_model.Description, model.Description);
        }

        [TestMethod]
        public void GetList_Test()
        {
            var _model = _applicationDbContext.Types;
            var model = _typesRepository.GetList();

            Assert.AreEqual(model.Count(), _model.Count());
        }

        [TestMethod]
        public void Update_Valid_Test()
        {
            var model = _applicationDbContext.Types.First();

            model.Description = "Zmiana";

            if (_typesRepository.Update(model))
            {
                var modelResponde = _applicationDbContext.Types.FirstOrDefault(t => t.ID == model.ID);
                Assert.IsNotNull(modelResponde);
                Assert.AreEqual(modelResponde.Description, model.Description);

                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Update_Not_Valid_Test()
        {
            var model = _applicationDbContext.Types.First();

            model.Description = "Tiro";

            try
            {
                _typesRepository.Update(model);
            }
            catch
            {
                Assert.IsTrue(true);

                return;
            }

            Assert.Fail();
        }
    }
}