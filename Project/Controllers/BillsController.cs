using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [RoutePrefix("project/bills")]
    public class BillsController : ApiController
    {
        private IBillsService billsService;
        private IOffersService offersService;
        private IUsersService usersService;

        public BillsController(IBillsService billsService, IOffersService offersService, IUsersService usersService)
        {
            this.billsService = billsService;
            this.offersService = offersService;
            this.usersService = usersService;
        }

        // GET: /project/bills - vraca listu svih racuna
        [Route("")]
        public IEnumerable<BillModel> GetBills()
        {
            return billsService.GetAllBills();
        }

        // POST: /project/bills - dodavanje novog racuna
        [Route("", Name = "PostBill")]
        [ResponseType(typeof(BillModel))]
        public IHttpActionResult PostBill(BillModel bill)
        {
            if (!ModelState.IsValid || bill.OfferID == null || bill.BuyerID == null)
            {
                return BadRequest(ModelState);
            }

            OfferModel offer = offersService.GetOffer((int)bill.OfferID);
            UserModel buyer = usersService.GetUser((int)bill.BuyerID);

            if (offer == null || buyer == null)
            {
                return NotFound();
            }

            if (buyer.UserRole != UserRoles.ROLE_CUSTOMER)
            {
                return BadRequest("User's role must be ROLE_CUSTOMER");
            }

            bill.Offer = offer;
            bill.Buyer = buyer;
            BillModel createdBill = billsService.CreateBill(bill);

            return CreatedAtRoute("PostBill", new { id = createdBill.ID }, createdBill);
        }

        // PUT: /project/bills/{id} - promena postojeceg racuna
        [Route("{id:int}")]
        [ResponseType(typeof(BillModel))]
        public IHttpActionResult PutBill(int id, BillModel bill)
        {
            if (!ModelState.IsValid || bill.OfferID == null || bill.BuyerID == null)
            {
                return BadRequest(ModelState);
            }

            if (id != bill.ID)
            {
                return BadRequest();
            }

            OfferModel offer = offersService.GetOffer((int)bill.OfferID);
            UserModel buyer = usersService.GetUser((int)bill.BuyerID);

            if (offer == null || buyer == null)
            {
                return NotFound();
            }

            if (buyer.UserRole != UserRoles.ROLE_CUSTOMER)
            {
                return BadRequest("User's role must be ROLE_CUSTOMER");
            }

            bill.Offer = offer;
            bill.Buyer = buyer;
            BillModel updatedBill = billsService.UpdateBill(id, bill);

            if (updatedBill == null)
            {
                return NotFound();
            }

            return Ok(updatedBill);
        }

        // DELETE: /project/bills/{id} - brisanje postojeceg racuna
        [Route("{id:int}")]
        [ResponseType(typeof(BillModel))]
        public IHttpActionResult DeleteBill(int id)
        {
            BillModel bill = billsService.DeleteBill(id);

            if (bill == null)
            {
                return NotFound();
            }

            return Ok(bill);
        }

        // GET: /project/bills/findByBuyer/{buyerId} - vraca racune po vrednosti prosledjenog ID-a kupca
        [Route("findByBuyer/{buyerId:int}")]
        public IEnumerable<BillModel> GetBillsByBuyer(int buyerId)
        {
            return billsService.GetBillsByBuyer(buyerId);
        }

        // GET: /project/bills/findByCategory/{categoryId} - vraca racune po vrednosti prosledjenog ID-a kategorije
        [Route("findByCategory/{categoryId:int}")]
        public IEnumerable<BillModel> GetBillsByCategory(int categoryId)
        {
            return billsService.GetBillsByCategory(categoryId);
        }

        // GET: /project/bills/findByDate/{startDate}/and/{endDate} - vraca racune kreirane u datom vremenskom intervalu
        [Route("findByDate/{startDate}/and/{endDate}")]
        public IEnumerable<BillModel> GetBillsByDatePeriod(DateTime startDate, DateTime endDate)
        {
            return billsService.GetBillsByDatePeriod(startDate, endDate);
        }
    }
}