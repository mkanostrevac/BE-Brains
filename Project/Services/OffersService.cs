using System.Collections.Generic;
using System.Linq;
using Project.Models;
using Project.Repositories;

namespace Project.Services
{
    public class OffersService : IOffersService
    {
        private IUnitOfWork db;

        public OffersService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<OfferModel> GetAllOffers()
        {
            return db.OffersRepository.Get();
        }

        public OfferModel CreateOffer(OfferModel newOffer)
        {
            db.OffersRepository.Insert(newOffer);
            db.Save();

            return newOffer;
        }

        public OfferModel UpdateOffer(int id, OfferModel offer)
        {
            OfferModel updatedOffer = db.OffersRepository.GetByID(id);

            if (updatedOffer != null)
            {
                updatedOffer.Name = offer.Name;
                updatedOffer.Description = offer.Description;
                updatedOffer.Created = offer.Created;
                updatedOffer.Expires = offer.Expires;
                updatedOffer.RegularPrice = offer.RegularPrice;
                updatedOffer.ActionPrice = offer.ActionPrice;
                updatedOffer.ImagePath = offer.ImagePath;
                updatedOffer.AvailableOffers = offer.AvailableOffers;
                updatedOffer.BoughtOffers = offer.BoughtOffers;

                db.OffersRepository.Update(updatedOffer);
                db.Save();
            }

            return updatedOffer;
        }

        public OfferModel DeleteOffer(int id)
        {
            OfferModel offer = db.OffersRepository.GetByID(id);

            if (offer != null)
            {
                db.OffersRepository.Delete(offer);
                db.Save();
            }

            return offer;
        }

        public OfferModel GetOffer(int id)
        {
            return db.OffersRepository.GetByID(id);
        }

        public OfferModel UpdateOfferStatus(int id, OfferStatuses newStatus)
        {
            OfferModel offer = db.OffersRepository.GetByID(id);

            if (offer != null)
            {
                offer.Status = newStatus;
                db.OffersRepository.Update(offer);
                db.Save();
            }

            return offer;
        }

        public IEnumerable<OfferModel> GetOffersByActionPriceRange(double lowerPrice, double upperPrice)
        {
            return db.OffersRepository.Get(x => x.ActionPrice >= lowerPrice && x.ActionPrice <=upperPrice);
        }
    }
}