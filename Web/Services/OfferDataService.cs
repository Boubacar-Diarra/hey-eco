using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;

namespace Web.Services
{
    public class OfferDataService : IOfferDataService
    {
        private readonly ApplicationDbContext _dbContext;
        public OfferDataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Offer>> GetAllOffers()
        {
            return Task.FromResult(_dbContext.Offers.ToList());
        }

        public async Task<Offer> GetOffer(long id)
        {
            return await _dbContext.Offers.FindAsync(id);
        }

        public Task<Offer> GetOffer(Offer offer)
        {
            throw new NotImplementedException();
        }

        public Task<List<Offer>> GetOffersByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public Task<List<Offer>> GetOffersByPublishDateInterval(DateTime start, DateTime end)
        {
            throw new NotImplementedException();
        }

        public Task<List<Offer>> GetOffersByType(string type)
        {
            throw new NotImplementedException();
        }

        public void UpdateOffer(long id, Offer offer)
        {
            throw new NotImplementedException();
        }

        public async void UpdateOffer(Offer offer)
        {
            _dbContext.Offers.Update(offer);
            await _dbContext.SaveChangesAsync();
        }

        public async void DeleteOffer(long id)
        {
            var offer = await _dbContext.Offers.FindAsync(id);
            _dbContext.Offers.Remove(offer);
            await _dbContext.SaveChangesAsync();
        }

        public async void Save(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Offer>> GetOffersByUser(string userId)
        {
            return Task.FromResult(
                _dbContext.Offers.Where(o => o.Author == userId).ToList()
            );
        }

        public Task<List<Offer>> GetOffersByUser(string userId, int startIndex, int count)
        {
            return Task.FromResult(
                _dbContext.Offers.Include(o => o.Applicants).Where(o => o.Author == userId).OrderByDescending(o => o.PublishDate).Skip(startIndex).Take(count).ToList()
                );
        }

        public bool SaveWithResult(Offer offer)
        {
            try
            {
                _dbContext.Offers.Add(offer);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public Task<List<Offer>> GetOffersForHome(User user, int startIndex, int count)
        {
            var byUserPreference = _dbContext.Offers
                .Include(o => o.Applicants)
                .Where(o => User.AreasOfExpertiseString.Contains(o.Category))
                .Where(o => o.Applicants.All(u => u.Id != user.Id))
                .Where(o => o.Author != user.Id)
                .OrderByDescending(o => o.PublishDate)
                .Skip(startIndex).Take(count).ToList();
            if(byUserPreference != null && byUserPreference.Count > 0)
            {
                return Task.FromResult(byUserPreference);
            }
            return Task.FromResult(
                _dbContext.Offers
                    .Include(o => o.Applicants)
                    .Where(o => o.Author != user.Id)
                    .Where(o => o.Applicants.All(u => u.Id != user.Id))
                    .OrderByDescending(o => o.PublishDate)
                    .Skip(startIndex).Take(count).ToList()
                );
        }

        public bool AddAppliant(Offer offer, User applicant)
        {
            try
            {
                _dbContext.Entry(offer).State = EntityState.Modified;
                _dbContext.Entry(applicant).State = EntityState.Modified;
                offer.Applicants.Add(applicant);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
