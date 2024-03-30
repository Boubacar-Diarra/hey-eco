using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using main.Models;

namespace main.Services
{
    public interface IOfferDataService
    {
        Task<Offer> GetOffer(long id);
        Task<Offer> GetOffer(Offer offer);
        Task<List<Offer>> GetAllOffers();
        Task<List<Offer>> GetOffersByUser(string userId);
        Task<List<Offer>> GetOffersByUser(string userId, int startIndex, int count);
        Task<List<Offer>> GetOffersByType(string type);
        Task<List<Offer>> GetOffersByCategory(string category);
        Task<List<Offer>> GetOffersForHome(User user, int startIndex, int count);
        Task<List<Offer>> GetOffersByPublishDateInterval(DateTime start, DateTime end);
        void UpdateOffer(long id, Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(long id);
        void Save(Offer offer);
        bool SaveWithResult(Offer offer);
        bool AddApplicant(Offer offer, Applicant applciant);
        bool RemoveApplicant(Offer offer, Applicant applciant);
        bool AcceptApplicant(Offer offer, Applicant applciant);
    }
}
