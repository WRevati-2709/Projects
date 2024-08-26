using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Application
{
    /// <summary>
    /// AdvisorService class
    /// </summary>
    public class AdvisorService : IAdvisorService
    {
        private readonly IAdvisorRepository advisorRepository;

        /// <summary>
        /// AdvisorService Constructor
        /// </summary>
        /// <param name="advisorRepository"></param>
        public AdvisorService(IAdvisorRepository advisorRepository)
        {
            this.advisorRepository = advisorRepository;
        }
        /// <inheritdoc cref="Advisor.Application.IAdvisorService.GetAllAdvisors()" />
        public async Task<IEnumerable<Advisor.Domain.Advisor>> GetAllAdvisors()
        {
            return await this.advisorRepository.GetAllAdvisors();
        }
        /// <inheritdoc cref="Advisor.Application.IAdvisorService.GetAdvisor(int id)" />
        public async Task<Advisor.Domain.Advisor> GetAdvisor(int id)
        {
            return await this.advisorRepository.GetAdvisor(id);
        }
        /// <inheritdoc cref="Advisor.Application.IAdvisorService.PutAdvisor(int id, Advisor.Domain.Advisor advisor)" />
        public async Task<string> PutAdvisor(int id, Advisor.Domain.Advisor advisor)
        {
            return await this.advisorRepository.PutAdvisor(id, advisor);
        }
        /// <inheritdoc cref="Advisor.Application.IAdvisorService.PostAdvisor(Advisor.Domain.Advisor objAdvisor)" />
        public async Task<int> PostAdvisor(Advisor.Domain.Advisor objAdvisor)
        {
            return await this.advisorRepository.PostAdvisor(objAdvisor);
        }
        /// <inheritdoc cref="Advisor.Application.IAdvisorService.DeleteAdvisor(int id)" />
        public async Task<bool> DeleteAdvisor(int id)
        {
            return await this.advisorRepository.DeleteAdvisor(id);
        }
    }
}
