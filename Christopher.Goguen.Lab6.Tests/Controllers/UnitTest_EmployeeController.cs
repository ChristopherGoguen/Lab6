using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Christopher.Goguen.Lab6.Models;
using Christopher.Goguen.Lab6.Controllers;
using System.Diagnostics.Tracing;

namespace Christopher.Goguen.Lab6.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmployeeController_Create()
        {
            // Arrange
            Employee employee = new Employee()
            {
               FirstName = "Chris",
               LastName = "Goguen",
               Gender = -1,
               Birthdate = "Jan",
               EmployeeId = 7,

            };

            EmployeesController controller = new EmployeesController(new FakeEmployeeRepository());


            System.Web.Mvc.RedirectToRouteResult result = controller.Create(employee) as System.Web.Mvc.RedirectToRouteResult;


            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void EmployeeController_Delete()
        {
         

            EmployeesController controller = new EmployeesController(new FakeEmployeeRepository());

            Employee employee = new Employee()
            {
                FirstName = "Chris",
                LastName = "Goguen",
                Gender = -1,
                Birthdate = "Jan",
                EmployeeId = 7,

            };

          System.Web.Mvc.RedirectToRouteResult result = controller.Create(employee) as System.Web.Mvc.RedirectToRouteResult;

          System.Web.Mvc.RedirectToRouteResult deleteResult = controller.DeleteConfirmed(7) as System.Web.Mvc.RedirectToRouteResult;

          System.Web.Mvc.RedirectToRouteResult model = controller.Details(7) as System.Web.Mvc.RedirectToRouteResult;

          Assert.IsNotNull(result);
          Assert.IsNotNull(deleteResult);
          Assert.IsNull(model);
                
            


        }
    }
}
