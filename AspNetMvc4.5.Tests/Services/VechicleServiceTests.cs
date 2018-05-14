using AspNetMvc4._5.Context;
using AspNetMvc4._5.ModelViews;
using AspNetMvc4._5.Services.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AspNetMvc4._5.Services.Tests
{
    [TestClass()]
    public class VechicleServiceTests
    {
        private readonly ITypesService _typesService = new TypesService();
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

        [TestMethod()]
        public void Add_Valid_Test()
        {
            var model = new TypesCreateModel() { Description = "Tirowe" };

            try
            {
                _typesService.Add(model);
            }
            catch
            {
                Assert.Fail();

                return;
            }

            Assert.IsTrue(_applicationDbContext.Types.Any(t => t.Description.CompareTo(model.Description) == 0));
        }

        [TestMethod()]
        public void Add_Not_Valid_Test()
        {
            var model = new TypesCreateModel() { Description = "Tir" };

            try
            {
                _typesService.Add(model);
            }
            catch
            {
                Assert.IsTrue(true);

                return;
            }

            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var model = _applicationDbContext.Types.First();

            _typesService.Delete(model.ID);

            Assert.IsFalse(_applicationDbContext.Types.Any(t => t.ID == model.ID));
        }

        [TestMethod()]
        public void GetEditViewTest()
        {
            var model = _applicationDbContext.Types.First();

            TypesUpdateModel updateModel = _typesService.GetEditView(model.ID);

            Assert.IsNotNull(updateModel);
        }

        [TestMethod()]
        public void GetListViewTest()
        {
            var _model = _applicationDbContext.Types;
            var model = _typesService.GetListView();

            Assert.AreEqual(model.Count(), _model.Count());
        }

        [TestMethod()]
        public void GetViewTest()
        {
            var model = _applicationDbContext.Types.First();

            TypesViewModel updateModel = _typesService.GetView(model.ID);

            Assert.IsNotNull(updateModel);
        }

        [TestMethod()]
        public void Update_Valid_Test()
        {
            var model = _applicationDbContext.Types.First();
            model.Description = "Zmiana";

            try
            {
                _typesService.Update(model.ID, new TypesUpdateModel(model));

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
    }
}