using System.Collections.Generic;
using System.Threading.Tasks;
using main.Models;

namespace main.Services
{
    public interface IApplicantDataService
    {
        Task<List<Applicant>> GetApplicantByUser(User user, int startIndex, int count);
    }
}