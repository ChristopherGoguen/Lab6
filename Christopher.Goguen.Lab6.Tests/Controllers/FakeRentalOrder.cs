using Christopher.Goguen.Lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Christopher.Goguen.Lab6.Tests.Controllers
{
    public class FakeRentalOrder : IRepository<RentalOrder>
    {
        List<RentalOrder> ro;

        public FakeRentalOrder()
        {
            ro = new List<RentalOrder>();
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public ICollection<RentalOrder> Get()
        {
            return ro;
        }

        public RentalOrder Get(int? id)
        {
            RentalOrder myRp = ro.Where(g => g.RentalOrderId == id).First();
            return myRp;
        }

        public void Post(RentalOrder model)
        {
            ro.Add(model);
        }

        public void Put(RentalOrder model)
        {
            throw new NotImplementedException();
        }
    }
}
