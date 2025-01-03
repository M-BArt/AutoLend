using AutoLend.Application.Services.Interfaces;
using AutoLend.Domain.DataModels.Customer;
using AutoLend.Domain.Interfaces;

namespace AutoLend.Application.Services {
    internal class CustomerService : ICustomerService {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService( ICustomerRepository customerRepository ) {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer?>> GetAllCustomers() {
            return await _customerRepository.GetAllAsync();
        }

        public async Task DeleteCustomer( Guid customerId) {
            await _customerRepository.DeleteAsync(customerId);
        }

        public async Task CreateCustomer( Customer customer) {
            await _customerRepository.CreateAsync(customer);
        }

        public async Task UpdateCustomer( Customer customer ) {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task<Customer?> GetCustomerById( Guid customerId ) {
            return await _customerRepository.GetByIdAsync(customerId);
        }
    }
}
