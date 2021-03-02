using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Data;
using Web.Models;

namespace Web.Services
{
    public class ApplicantDataService : IApplicantDataService
    {
        private readonly ApplicationDbContext _dbContext;

        public ApplicantDataService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Applicant>> GetApplicantByUser(User user, int startIndex, int count)
        {
            return await _dbContext.Applicants
                .Where(a => a.User.Id == user.Id)
                .OrderByDescending(a => a.DateOfRequest)
                .Skip(startIndex)
                .Take(count)
                .ToListAsync();
        }
    }
}