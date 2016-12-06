using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Christopher.Goguen.Lab6.Models
{
    public class EmployeeRepository : IRepository<Employee>
    {
       private SheridanSystem db = new SheridanSystem();

            // Get many (Index)
            public ICollection<Employee> Get()
            {
            return db.Employees.ToList();
            }

            // Get one (Details)
            public Employee Get(int? id)
            {
                return db.Employees.Find(id);
            }

            // Post (Create)
            public void Post(Employee _employee)
            {
                db.Employees.Add(_employee);
                db.SaveChanges();
            }

            // Put (Update)
            public void Put(Employee _employee)
            {
                db.Entry(_employee).State = EntityState.Modified;
                db.SaveChanges();
            }

            // Delete
            public void Delete(int? id)
            {
                Employee _employee = db.Employees.Find(id);
                db.Employees.Remove(_employee);
                db.SaveChanges();
            }
        }

    }
