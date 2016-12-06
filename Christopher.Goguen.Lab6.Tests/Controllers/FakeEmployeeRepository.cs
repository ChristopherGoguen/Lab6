using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Christopher.Goguen.Lab6.Models;
using Christopher.Goguen.Lab6.Controllers;

namespace Christopher.Goguen.Lab6.Tests.Controllers
{

    public class FakeEmployeeRepository : IRepository<Employee>
    {
        private List<Employee> emp;

        public FakeEmployeeRepository()
        {
            this.emp = new List<Employee>();
        }

        public void Delete(int? id)
        {
            Employee emps = emp.Where(r => r.EmployeeId == id).First();
            emp.Remove(emps);

        }

        public ICollection<Employee> Get()
        {
           throw new NotImplementedException();
        }

        public Employee Get(int? id)
        {
            return new Employee() { EmployeeId = (int)id };
        }

        public void Post(Employee model)
        {
            emp.Add(model);
       
        }

        public void Put(Employee model)
        {
            throw new NotImplementedException();
        }

    }
}



