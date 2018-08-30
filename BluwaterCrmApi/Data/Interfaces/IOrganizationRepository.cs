using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluwaterCrmApi.Models;

namespace BluwaterCrmApi.Data.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<Organization> SelectOrganizationByGuidAsync(Guid guid);
        Task<List<Organization>> ListAllOrganizationsAsync();
        Task CreateOrganizationAsync(Organization organization);
        Task UpdateOrganizationAsync(Organization organization);
        Task DeleteOrganizationAsync(Organization organization);
    }
}
