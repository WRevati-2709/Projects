using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Application
{
    /// <summary>
    /// IAdvisorRepository interface
    /// </summary>
    public interface IAdvisorRepository
    {
        /// <summary>
        /// This method was used to get all advisor details
        /// </summary>
        /// <returns>Returns list of Advisors</returns>
        Task<IEnumerable<Advisor.Domain.Advisor>> GetAllAdvisors();
        /// <summary>
        /// This method was used to get advisor details by advisor id.
        /// </summary>
        /// <param name="id">Advisor ID</param>
        /// <returns>Retunrs an Advisor Details</returns>
        Task<Advisor.Domain.Advisor> GetAdvisor(int id);
        /// <summary>
        /// This method was used to update an advisor details
        /// </summary>
        /// <param name="id">Advisor ID</param>
        /// <param name="advisor">Advisor Details</param>
        /// <returns>Return response in string</returns>
        Task<string> PutAdvisor(int id, Advisor.Domain.Advisor advisor);
        /// <summary>
        /// This method was used to insert an advisor details
        /// </summary>
        /// <param name="objAdvisor">Advisor Details</param>
        /// <returns>Return ID of an Advisor</returns>
        Task<int> PostAdvisor(Advisor.Domain.Advisor objAdvisor);
        /// <summary>
        /// This method is used to delete an advisor details
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Return true if sucessfully deleted an advisor</returns>
        Task<bool> DeleteAdvisor(int id);
    }
}
