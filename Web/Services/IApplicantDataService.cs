using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Services
{
    public interface IApplicantDataService
    {
        Task<List<Applicant>> GetApplicantByUser(User user, int startIndex, int count);
    }
}