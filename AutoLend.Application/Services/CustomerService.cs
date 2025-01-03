using AutoLend.Application.Services.Interfaces;
using AutoLend.Domain.DataModels.Client;
using AutoLend.Domain.Interfaces;

namespace AutoLend.Application.Services {
    internal class CustomerService : ICustomerService {

        private readonly ICustomerRepository _customerRepository;

        public CustomerService( ICustomerRepository clientRepository ) {
            _customerRepository = clientRepository;
        }

        public async Task<IEnumerable<Customer?>> GetAll() {
            return await _customerRepository.GetAllAsync();
        }

        public async Task Delete(Guid customerId) {
            await _customerRepository.DeleteAsync(customerId);
        }

        public async Task Create(Customer customer) {
            await _customerRepository.CreateAsync(customer);
        }

        public async Task Update( Customer customer ) {
            await _customerRepository.UpdateAsync(customer);
        }

        public async Task<Customer?> GetById( Guid customerId ) {
            return await _customerRepository.GetByIdAsync(customerId);
        }
    }
}
