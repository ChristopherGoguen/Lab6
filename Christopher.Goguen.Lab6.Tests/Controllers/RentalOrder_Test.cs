using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Christopher.Goguen.Lab6.Models;
using System.Web.Http.Results;
using Christopher.Goguen.Lab6.Controllers;
using System.Collections.Generic;
using System.Web.Http;

namespace Christopher.Goguen.Lab6.Tests.Controllers
{
    [TestClass]
    public class RentalOrder_Test
    {
        [TestMethod]
        public void RentalOrder_Get()
        {
      
            RentalOrdersApiController controller = new RentalOrdersApiController(new FakeRentalOrder());

            Employee emp = new Employee()
            {
                FirstName = "Chris",
                LastName = "Goguen",
                Birthdate = "Jan",
                EmployeeId = 10,
                Gender = -1

            };

            DateTime date = new DateTime(2015, 8, 18, 13, 31, 17);
            DateTime date2 = new DateTime(2015, 8, 18, 13, 31, 17);

            Inventory inv = new Inventory()
            {
                Category = "Gaming",
                InventoryId = 10,
                Name = "Xbox"
            };

            List<Inventory> invList = new List<Inventory>();
            invList.Add(inv);

            RentalOrder ro = new RentalOrder()
            {
                Employee = emp,
                CheckoutDate = date,
                EmployeeEmployeeId = 10,
                RentalOrderId = 10,
                ReturnDate = date2,
                UniqueId = 1235,
                Inventories = invList

            };

             CreatedAtRouteNegotiatedContentResult<RentalOrder> create = controller.PostRentalOrder(ro) as CreatedAtRouteNegotiatedContentResult<RentalOrder>;

               var result = controller.GetRentalOrders() as ICollection<RentalOrder>;
 
             Assert.IsNotNull(create);
             Assert.IsNotNull(result);

                     
        }

        [TestMethod]

        public void RentalOrder_GetOne()
        {

            RentalOrdersApiController controller = new RentalOrdersApiController(new FakeRentalOrder());

            Employee emp = new Employee()
            {
                FirstName = "Chris",
                LastName = "Goguen",
                Birthdate = "Jan",
                EmployeeId = 10,
                Gender = -1

            };

            DateTime date = new DateTime(2015, 8, 18, 13, 31, 17);
            DateTime date2 = new DateTime(2015, 8, 18, 13, 31, 17);

            Inventory inv = new Inventory()
            {
                Category = "Gaming",
                InventoryId = 10,
                Name = "Xbox"
            };

            List<Inventory> invList = new List<Inventory>();
            invList.Add(inv);

            RentalOrder ro = new RentalOrder()
            {
                Employee = emp,
                CheckoutDate = date,
                EmployeeEmployeeId = 10,
                RentalOrderId = 10,
                ReturnDate = date2,
                UniqueId = 1235,
                Inventories = invList
            };


            CreatedAtRouteNegotiatedContentResult<RentalOrder> create = controller.PostRentalOrder(ro) as CreatedAtRouteNegotiatedContentResult<RentalOrder>;

            OkNegotiatedContentResult<RentalOrder> result = controller.GetRentalOrder(10) as OkNegotiatedContentResult<RentalOrder>;
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsNotNull(create);
           
        }
    }
}
