using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    interface IOfferDataService
    {
        Task<Offer> GetOffer(long id);
        Task<Offer> GetOffer(Offer offer);
        Task<List<Offer>> GetAllOffers();
        Task<List<Offer>> GetOffersByUser(string userId);
        Task<List<Offer>> GetOffersByUser(string userId, int startIndex, int count);
        Task<List<Offer>> GetOffersByType(string type);
        Task<List<Offer>> GetOffersByCategory(string category);
        Task<List<Offer>> GetOffersByPublishDateInterval(DateTime start, DateTime end);
        void UpdateOffer(long id, Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(long id);
        void Save(Offer offer);
        bool SaveWithResult(Offer offer);
    }
}
