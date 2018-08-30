using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BluwaterCrmApi.Data.Interfaces;
using BluwaterCrmApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BluwaterCrmApi.Data.Repositories
{
    public class CustomerRepository: ICustomerRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            return await _applicationDbContext.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomersByOrganizationAsync(int organizationId)
        {
            return await _applicationDbContext.Customers
                .Where(c => c.OrganizationId == organizationId)
                .ToListAsync();
        }

        public async Task<Customer> GetCustomerByGuidAsync(Guid customerGuid)
        {
            return await _applicationDbContext.Customers
                .Include(c => c.Notes)
                .Include(c => c.Deals)
                .Include(c => c.Organization)
                .SingleAsync(c => c.CustomerGuid == customerGuid);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            customer.CustomerGuid = Guid.NewGuid();
            await _applicationDbContext.Customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            customer.UpdatedTimestamp = DateTime.Now;
            _applicationDbContext.Customers.Update(customer);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(Guid customerGuid)
        {
            Customer customer = await _applicationDbContext.Customers
                .Where(c => c.CustomerGuid == customerGuid)
                .SingleAsync();
            _applicationDbContext.Customers.Remove(customer);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}
