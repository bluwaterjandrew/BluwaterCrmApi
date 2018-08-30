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
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomerAsync(string id)
        {
            Guid customerGuid = Guid.Parse(id);
            Customer customer = await _customerRepository.GetCustomerByGuidAsync(customerGuid);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            List<Customer> customers = await _customerRepository.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("organization/{id}")]
        [ProducesResponseType(200, Type = typeof(List<Customer>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetCustomersByOrganizationAsync(int id)
        {
            List<Customer> customers = await _customerRepository.GetCustomersByOrganizationAsync(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(Customer))]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _customerRepository.CreateCustomerAsync(customer);
            return Ok(customer);
        }

        [HttpPost("{id}")]
        [ProducesResponseType(200, Type = typeof(Customer))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody]Customer customer)
        {
            await _customerRepository.UpdateCustomerAsync(customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCustomerAsync(string id)
        {
            Guid customerGuid = Guid.Parse(id);
            await _customerRepository.DeleteCustomerAsync(customerGuid);
            return Ok();
        }
        
    }
}