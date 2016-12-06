using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Christopher.Goguen.Lab6.Models
{
    public class InventoryRepository : IRepository<Inventory>
    {
        private SheridanSystem db = new SheridanSystem();

        // Get many (Index)
        public ICollection<Inventory> Get()
        {
            return db.Inventories.ToList();
        }

        // Get one (Details)
        public Inventory Get(int? id)
        {
            return db.Inventories.Find(id);
        }

        // Post (Create)
        public void Post(Inventory _inv)
        {
            db.Inventories.Add(_inv);
            db.SaveChanges();
        }

        // Put (Update)
        public void Put(Inventory _inv)
        {
            db.Entry(_inv).State = EntityState.Modified;
            db.SaveChanges();
        }

        // Delete
        public void Delete(int? id)
        {
            Inventory _inv = db.Inventories.Find(id);
            db.Inventories.Remove(_inv);
            db.SaveChanges();
        }
    }
}
