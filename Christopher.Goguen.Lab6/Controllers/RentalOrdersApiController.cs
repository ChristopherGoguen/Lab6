using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Christopher.Goguen.Lab6.Models;

namespace Christopher.Goguen.Lab6.Controllers
{
    public class RentalOrdersApiController : ApiController
    {
        // private SheridanSystem db = new SheridanSystem();

        private IRepository<RentalOrder> repo;

        public RentalOrdersApiController(IRepository<RentalOrder> _repo)
        {
            this.repo = _repo;
        }

        public RentalOrdersApiController() 
            : this(new RentalOrderRepository())
        {
        }


        // GET: api/RentalOrdersApi
        public ICollection<RentalOrder> GetRentalOrders()
        { 
            return repo.Get();
        }

        // GET: api/RentalOrdersApi/5
        [ResponseType(typeof(RentalOrder))]
        public IHttpActionResult GetRentalOrder(int id)
        {
            RentalOrder rentalOrder = repo.Get(id);
            if (rentalOrder == null)
            {
                return NotFound();
            }

            return Ok(rentalOrder);
        }

        // PUT: api/RentalOrdersApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRentalOrder(int id, RentalOrder rentalOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rentalOrder.RentalOrderId)
            {
                return BadRequest();
            }


            try
            {
                repo.Put(rentalOrder);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalOrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RentalOrdersApi
        [ResponseType(typeof(RentalOrder))]
        public IHttpActionResult PostRentalOrder(RentalOrder rentalOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            repo.Post(rentalOrder);


            return CreatedAtRoute("DefaultApi", new { id = rentalOrder.RentalOrderId }, rentalOrder);
        }

        // DELETE: api/RentalOrdersApi/5
        [ResponseType(typeof(RentalOrder))]
        public IHttpActionResult DeleteRentalOrder(int id)
        {
            RentalOrder rentalOrder = repo.Get(id);
            if (rentalOrder == null)
            {
                return NotFound();
            }

            repo.Put(rentalOrder);

            return Ok(rentalOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
               // db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RentalOrderExists(int id)
        {
            return (repo.Get(id) != null);
        }
    }
}