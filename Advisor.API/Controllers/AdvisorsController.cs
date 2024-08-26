using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Advisor.Domain;
using Advisor.Application;

namespace Advisor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvisorsController : ControllerBase
    {
        private readonly IAdvisorService advisorService;

        public AdvisorsController(IAdvisorService advisorService)
        {
            this.advisorService = advisorService;
        }

        // GET: api/Advisors
        /// <summary>
        /// This web API is used to get all advisor details
        /// </summary>
        /// <returns>Returns all advisor list</returns>
        [HttpGet]
        public async Task<IEnumerable<Advisor.Domain.Advisor>> GetAdvisors()
        {
            return await advisorService.GetAllAdvisors();
        }

        // GET: api/Advisors/5
        /// <summary>
        /// This web API is used to get advisor details by advisor id.
        /// </summary>
        /// <param name="id">Advisor ID</param>
        /// <returns>Retunrs an Advisor Details</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Advisor.Domain.Advisor>> GetAdvisor(int id)
        {
            var advisor = await advisorService.GetAdvisor(id);

            if (advisor == null)
            {
                return NotFound();
            }

            return advisor;
        }

        // PUT: api/Advisors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// This web API was used to update an advisor details
        /// </summary>
        /// <param name="id">Advisor ID</param>
        /// <param name="advisor">Advisor Details</param>
        /// <returns>Return response in string</returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> PutAdvisor(int id, Advisor.Domain.Advisor advisor)
        {
            if (id != advisor.Id)
            {
                return BadRequest();
            }
            return await advisorService.PutAdvisor(id, advisor);
        }

        // POST: api/Advisors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// This web API was used to insert an advisor details
        /// </summary>
        /// <param name="objAdvisor">Advisor Details</param>
        /// <returns>Return an updated Advisor</returns>
        [HttpPost]
        public async Task<ActionResult<Advisor.Domain.Advisor>> PostAdvisor(Advisor.Domain.Advisor advisor)
        {
            int advisorID = await advisorService.PostAdvisor(advisor);
            if (advisorID == 0)
                return BadRequest();
            else
                return CreatedAtAction("GetAdvisor", new { id = advisorID }, advisor);
        }

        // DELETE: api/Advisors/5
        /// <summary>
        /// This web API is used to delete an advisor details
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>Returns no content if sucessfully deleted an advisor</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvisor(int id)
        {
            if (!await advisorService.DeleteAdvisor(id))
                return NoContent();
            else
                return NotFound();
        }


    }
}
