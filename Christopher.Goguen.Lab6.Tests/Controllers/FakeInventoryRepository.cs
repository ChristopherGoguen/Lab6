using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Christopher.Goguen.Lab6.Models;

namespace Christopher.Goguen.Lab6.Tests.Controllers
{
    class FakeInventoryRepository : IRepository<Inventory>
    {
        List<Inventory> inv;

        public FakeInventoryRepository()
        {
            inv = new List<Inventory>();
         }

        public void Delete(int? id)
        {
            throw new NotImplementedException();

        }

        public ICollection<Inventory> Get()
        {
        
            return inv;
        }

        public Inventory Get(int? id)
        {

            return new Inventory() { InventoryId = (int)id };
        }

        public void Post(Inventory model)
        {
            inv.Add(model);

        }

        public void Put(Inventory model)
        {
            throw new NotImplementedException();
        }
    }
}
