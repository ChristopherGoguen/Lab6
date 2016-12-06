using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Christopher.Goguen.Lab6.Models
{
    public class RentalOrderRepository : IRepository<RentalOrder>
    {
        private SheridanSystem db = new SheridanSystem();

        public void Delete(int? id)
        {
            RentalOrder _inv = db.RentalOrders.Find(id);
            db.RentalOrders.Remove(_inv);
            db.SaveChanges();
        }

        public ICollection<RentalOrder> Get()
        {
            return db.RentalOrders.ToList();
        }

        public RentalOrder Get(int? id)
        {
            return db.RentalOrders.Find(id);
        }

        public void Post(RentalOrder model)
        {
            db.RentalOrders.Add(model);
            db.SaveChanges();
        }

        public void Put(RentalOrder model)
        {
            db.Entry(model).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}