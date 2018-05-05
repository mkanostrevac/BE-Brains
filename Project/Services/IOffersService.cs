using System.Collections.Generic;
using Project.Models;

namespace Project.Services
{
    public interface IOffersService
    {
        IEnumerable<OfferModel> GetAllOffers();

        OfferModel CreateOffer(OfferModel newOffer);

        OfferModel UpdateOffer(int id, OfferModel offer);

        OfferModel DeleteOffer(int id);

        OfferModel GetOffer(int id);

        OfferModel UpdateOfferStatus(int id, OfferStatuses newStatus);

        IEnumerable<OfferModel> GetOffersByActionPriceRange(double lowerPrice, double upperPrice);
    }
}
