﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    [RoutePrefix("project/offers")]
    public class OffersController : ApiController
    {
        private IOffersService offersService;
        private ICategoriesService categoriesService;
        private IUsersService usersService;

        public OffersController(IOffersService offersService, ICategoriesService categoriesService, IUsersService usersService)
        {
            this.offersService = offersService;
            this.categoriesService = categoriesService;
            this.usersService = usersService;
        }

        // GET: /project/offers - vraca listu svih ponuda
        [Route("")]
        public IEnumerable<OfferModel> GetOffers()
        {
            return offersService.GetAllOffers();
        }

        // POST: /project/offers - dodavanje nove ponude
        [Route("", Name = "PostOffer")]
        [ResponseType(typeof(OfferModel))]
        public IHttpActionResult PostOffer(OfferModel offer)
        {
            if (!ModelState.IsValid || offer.CategoryID == null || offer.SellerID == null)
            {
                return BadRequest(ModelState);
            }

            CategoryModel category = categoriesService.GetCategory((int)offer.CategoryID);
            UserModel seller = usersService.GetUser((int)offer.SellerID);

            if (category == null || seller == null)
            {
                return NotFound();
            }

            if (seller.UserRole != UserRoles.ROLE_SELLER)
            {
                return BadRequest("User's role must be ROLE_SELLER");
            }

            offer.Category = category;
            offer.Seller = seller;
            OfferModel createdOffer = offersService.CreateOffer(offer);

            return CreatedAtRoute("PostOffer", new { id = createdOffer.ID }, createdOffer);
        }

        // PUT: /project/offers/{id} - promena postojece ponude
        [Route("{id:int}")]
        [ResponseType(typeof(OfferModel))]
        public IHttpActionResult PutOffer(int id, OfferModel offer)
        {
            if (!ModelState.IsValid || offer.CategoryID == null  || offer.SellerID == null)
            {
                return BadRequest(ModelState);
            }

            if (id != offer.ID)
            {
                return BadRequest();
            }

            CategoryModel category = categoriesService.GetCategory((int)offer.CategoryID);
            UserModel seller = usersService.GetUser((int)offer.SellerID);

            if (category == null || seller == null)
            {
                return NotFound();
            }

            if (seller.UserRole != UserRoles.ROLE_SELLER)
            {
                return BadRequest("User's role must be ROLE_SELLER");
            }

            offer.Category = category;
            offer.Seller = seller;
            OfferModel updatedOffer = offersService.UpdateOffer(id, offer);

            if (updatedOffer == null)
            {
                return NotFound();
            }

            return Ok(updatedOffer);
        }

        // DELETE: /project/offers/{id} - brisanje postojece ponude
        [Route("{id:int}")]
        [ResponseType(typeof(OfferModel))]
        public IHttpActionResult DeleteOffer(int id)
        {
            OfferModel offer = offersService.DeleteOffer(id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        // GET: /project/offers/{id} - vraca ponudu po vrednosti prosledjenog ID-a
        [Route("{id:int}")]
        [ResponseType(typeof(OfferModel))]
        public IHttpActionResult GetOffer(int id)
        {
            OfferModel offer = offersService.GetOffer(id);

            if (offer == null)
            {
                return NotFound();
            }

            return Ok(offer);
        }

        // PUT: /project/offers/changeOffer/{id}/status/{status} - promena statusa postojece ponude
        [Route("changeOffer/{id}/status/{status}")]
        [ResponseType(typeof(OfferModel))]
        public IHttpActionResult PutOfferStatus(int id, OfferStatuses status)
        {
            OfferModel offerWithUpdatedStatus = offersService.UpdateOfferStatus(id, status);

            if (offerWithUpdatedStatus == null)
            {
                return NotFound();
            }

            return Ok(offerWithUpdatedStatus);
        }

        // GET: /project/offers/findByPrice/{lowerPrice}/and/{upperPrice} - vraca ponude cija se akcijska cena nalazi u prosledjenom rasponu
        [Route("findByPrice/{lowerPrice}/and/{upperPrice}")]
        public IEnumerable<OfferModel> GetOffersByActionPriceRange(double lowerPrice, double upperPrice)
        {
            return offersService.GetOffersByActionPriceRange(lowerPrice, upperPrice);
        }
    }
}