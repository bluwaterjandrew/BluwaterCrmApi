using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluwaterCrmApi.Data.Interfaces;
using BluwaterCrmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BluwaterCrmApi.Data.Repositories
{
    public class OrganizationRepository: IOrganizationRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public OrganizationRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Organization> SelectOrganizationByGuidAsync(Guid guid)
        {
            Organization organization = await _applicationDbContext.Organizations
                                                .Where(o => o.OrganizationGuid == guid)
                                                .SingleAsync();
            return organization;
        }

        public async Task<List<Organization>> ListAllOrganizationsAsync()
        {
            return await _applicationDbContext.Organizations.ToListAsync();
        }

        public async Task CreateOrganizationAsync(Organization organization)
        {
            await _applicationDbContext.Organizations.AddAsync(organization);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateOrganizationAsync(Organization organization)
        {
            _applicationDbContext.Organizations.Update(organization);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteOrganizationAsync(Organization organization)
        {
            _applicationDbContext.Organizations.Remove(organization);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
