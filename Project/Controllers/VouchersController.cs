using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [RoutePrefix("project/vouchers")]
    public class VouchersController : ApiController
    {
        private IVouchersService vouchersService;
        private IOffersService offersService;
        private IUsersService usersService;

        public VouchersController(IVouchersService vouchersService, IOffersService offersService, IUsersService usersService)
        {
            this.vouchersService = vouchersService;
            this.offersService = offersService;
            this.usersService = usersService;
        }

        // GET: /project/vouchers - vraca listu svih vaucera
        [Route("")]
        public IEnumerable<VoucherModel> GetVouchers()
        {
            return vouchersService.GetAllVouchers();
        }

        // POST: /project/vouchers - dodavanje novog vaucera
        [Route("", Name = "PostVoucher")]
        [ResponseType(typeof(VoucherModel))]
        public IHttpActionResult PostVoucher(VoucherModel voucher)
        {
            if (!ModelState.IsValid || voucher.OfferID == null || voucher.BuyerID == null)
            {
                return BadRequest(ModelState);
            }

            OfferModel offer = offersService.GetOffer((int)voucher.OfferID);
            UserModel buyer = usersService.GetUser((int)voucher.BuyerID);

            if (offer == null || buyer == null)
            {
                return NotFound();
            }

            if (buyer.UserRole != UserRoles.ROLE_CUSTOMER)
            {
                return BadRequest("User's role must be ROLE_CUSTOMER");
            }

            voucher.Offer = offer;
            voucher.Buyer = buyer;
            VoucherModel createdVoucher = vouchersService.CreateVoucher(voucher);

            return CreatedAtRoute("PostVoucher", new { id = createdVoucher.ID }, createdVoucher);
        }

        // PUT: /project/vouchers/{id} - promena postojeceg vaucera
        [Route("{id:int}")]
        [ResponseType(typeof(VoucherModel))]
        public IHttpActionResult PutVoucher(int id, VoucherModel voucher)
        {
            if (!ModelState.IsValid || voucher.OfferID == null || voucher.BuyerID == null)
            {
                return BadRequest(ModelState);
            }

            if (id != voucher.ID)
            {
                return BadRequest();
            }

            OfferModel offer = offersService.GetOffer((int)voucher.OfferID);
            UserModel buyer = usersService.GetUser((int)voucher.BuyerID);

            if (offer == null || buyer == null)
            {
                return NotFound();
            }

            if (buyer.UserRole != UserRoles.ROLE_CUSTOMER)
            {
                return BadRequest("User's role must be ROLE_CUSTOMER");
            }

            voucher.Offer = offer;
            voucher.Buyer = buyer;
            VoucherModel updatedVoucher = vouchersService.UpdateVoucher(id, voucher);

            if (updatedVoucher == null)
            {
                return NotFound();
            }

            return Ok(updatedVoucher);
        }

        // DELETE: /project/vouchers/{id} - brisanje postojeceg vaucera
        [Route("{id:int}")]
        [ResponseType(typeof(VoucherModel))]
        public IHttpActionResult DeleteVoucher(int id)
        {
            VoucherModel voucher = vouchersService.DeleteVoucher(id);

            if (voucher == null)
            {
                return NotFound();
            }

            return Ok(voucher);
        }

        // GET: /project/vouchers/findByBuyer/{buyerId} - vraca vaucere po vrednosti prosledjenog ID-a kupca
        [Route("findByBuyer/{buyerId:int}")]
        public IEnumerable<VoucherModel> GetVouchersByBuyer(int buyerId)
        {
            return vouchersService.GetVouchersByBuyer(buyerId);
        }

        // GET: /project/vouchers/findByOffer/{offerId} - vraca vaucere po vrednosti prosledjenog ID-a ponude
        [Route("findByOffer/{offerId:int}")]
        public IEnumerable<VoucherModel> GetVouchersByOffer(int offerId)
        {
            return vouchersService.GetVouchersByOffer(offerId);
        }

        // GET: /project/vouchers/findNonExpiredVoucher - vraca vaucere koji nisu istekli
        [Route("findNonExpiredVoucher")]
        public IEnumerable<VoucherModel> GetNonExpiredVouchers()
        {
            return vouchersService.GetNonExpiredVouchers();
        }
    }
}