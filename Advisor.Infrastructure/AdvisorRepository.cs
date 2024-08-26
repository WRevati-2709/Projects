using Advisor.Application;
using Microsoft.EntityFrameworkCore;

namespace Advisor.Infrastructure
{
    /// <summary>
    /// AdvisorRepository Class
    /// </summary>
    public class AdvisorRepository : IAdvisorRepository
    {
        private readonly ApiContext _context;
        /// <summary>
        /// AdvisorRepository Constructor
        /// </summary>
        /// <param name="context"></param>
        public AdvisorRepository(ApiContext context)
        {
            _context = context;
        }

        /// <inheritdoc cref="Advisor.Application.IAdvisorRepository.GetAllAdvisors()" />
        public async Task<IEnumerable<Advisor.Domain.Advisor>> GetAllAdvisors()
        {
            return await _context.Advisors.ToListAsync();
        }

        /// <inheritdoc cref="Advisor.Application.IAdvisorRepository.GetAdvisor(int id)" />
        public async Task<Advisor.Domain.Advisor> GetAdvisor(int id)
        {
            return await _context.Advisors.FindAsync(id);
        }

        /// <inheritdoc cref="Advisor.Application.IAdvisorRepository.PutAdvisor(int id, Advisor.Domain.Advisor advisor)" />
        public async Task<string> PutAdvisor(int id, Advisor.Domain.Advisor advisor)
        {
            _context.Entry(advisor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvisorExists(id))
                {
                    return "No data found.";
                }
                else
                {
                    throw;
                }
            }
            return "Successfully updated an adisor details.";
        }

        /// <inheritdoc cref="Advisor.Application.IAdvisorRepository.PostAdvisor(Advisor.Domain.Advisor objAdvisor)" />
        public async Task<int> PostAdvisor(Advisor.Domain.Advisor objAdvisor)
        {
            _context.Advisors.Add(objAdvisor);
            await _context.SaveChangesAsync();
            if (objAdvisor.Id != 0)
                return objAdvisor.Id;
            return 0;
        }

        /// <inheritdoc cref="Advisor.Application.IAdvisorRepository.DeleteAdvisor(int id)" />
        public async Task<bool> DeleteAdvisor(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor == null)
                return false;

            _context.Advisors.Remove(advisor);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// This method is used to check advisor is exist in system or not
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns true if exists or else return false</returns>
        private bool AdvisorExists(int id)
        {
            return _context.Advisors.Any(e => e.Id == id);
        }
    }
}
