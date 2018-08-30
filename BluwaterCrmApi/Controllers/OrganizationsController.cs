using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluwaterCrmApi.Data.Interfaces;
using BluwaterCrmApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BluwaterCrmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly IOrganizationRepository _organizationRepository;

        public OrganizationsController(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetOrganizationByGuidAsync(string guid)
        {
            Guid organizationGuid = Guid.Parse(guid);
            Organization organization = await _organizationRepository.SelectOrganizationByGuidAsync(organizationGuid);
            if (organization == null)
            {
                return NotFound();
            }

            return Ok(organization);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Organization>))]
        public async Task<IActionResult> GetAllOrganizations()
        {
            List<Organization> organizations = await _organizationRepository.ListAllOrganizationsAsync();
            return Ok(organizations);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Organization))]
        public async Task<IActionResult> CreateOrganizationAsync(Organization organization)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _organizationRepository.CreateOrganizationAsync(organization);
            return StatusCode(201, organization);
        }

        [HttpPost("{guid}")]
        [ProducesResponseType(200, Type = typeof(Organization))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateOrganizationAsync(Organization organization, string guid)
        {
            Guid organizationGuid = Guid.Parse(guid);
            // Check if org exists - May remove this later
            Organization _organization = await _organizationRepository.SelectOrganizationByGuidAsync(organizationGuid);
            if (_organization == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _organizationRepository.UpdateOrganizationAsync(organization);
            return Ok(organization);
        }

        [HttpDelete("{guid}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteOrganizationAsync(string guid)
        {
            Guid organizationGuid = Guid.Parse(guid);
            Organization organization = await _organizationRepository.SelectOrganizationByGuidAsync(organizationGuid);
            if (organization == null)
            {
                return NotFound();
            }

            await _organizationRepository.DeleteOrganizationAsync(organization);
            return Ok();
        }
    }
}