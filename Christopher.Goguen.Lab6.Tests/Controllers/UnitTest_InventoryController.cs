using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Christopher.Goguen.Lab6.Models;
using Christopher.Goguen.Lab6.Controllers;
using System.Web.Http.Results;
using Christopher.Goguen.Lab6.Fakes;
using Christopher.Goguen.Lab6.Models.Fakes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Christopher.Goguen.Lab6.Tests.Controllers
{
    [TestClass]
    public class UnitTest_InventoryController
    {
        [TestMethod]
        public void InventoryController_GetAll()
        {
               Inventory inve = new Inventory()
             {
              Name = "Xbox", Category = "Gaming", InventoryId = 10
            };

            InventoriesController controller = new InventoriesController(new FakeInventoryRepository());

            System.Web.Mvc.RedirectToRouteResult create = controller.Create(inve) as System.Web.Mvc.RedirectToRouteResult;

               System.Web.Mvc.ViewResult result = controller.Index() as System.Web.Mvc.ViewResult;

            Assert.IsNotNull(create);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void InventoryController_GetOne()
        {
            InventoriesController controller = new InventoriesController(new FakeInventoryRepository());

            Inventory inv = new Inventory()
            {
                Name = "Xbox",
                Category = "Game",
                InventoryId = 10
            };

            System.Web.Mvc.RedirectToRouteResult result = controller.Create(inv) as System.Web.Mvc.RedirectToRouteResult;

            System.Web.Mvc.ViewResult find = controller.Details(10) as System.Web.Mvc.ViewResult;
             Assert.IsNotNull(result);
            Assert.IsNotNull(find);

        }



        [TestMethod]

        public void InventoryController_GetAllSub()
        {


            StubIRepository<Inventory> stubRepo = new StubIRepository<Inventory>();

            stubRepo.Get = () =>
            new List<Inventory>
            {
                new Inventory() { Name = "Xbox", Category= "Gaming", InventoryId =10 }
            };

            InventoriesController controller = new InventoriesController(stubRepo);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Model);

            List<Inventory> resultList = result.Model as List<Inventory>;
            Assert.AreEqual(1, resultList.Count);

        }

    }
}
