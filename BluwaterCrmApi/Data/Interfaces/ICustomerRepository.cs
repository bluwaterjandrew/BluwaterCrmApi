using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluwaterCrmApi.Models;

namespace BluwaterCrmApi.Data.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<List<Customer>> GetCustomersByOrganizationAsync(int organizationId);
        Task<Customer> GetCustomerByGuidAsync(Guid customerGuid);
        Task CreateCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task DeleteCustomerAsync(Guid customerGuid);

    }
}
