using AutoLend.Core.ApiModels.Customer;
using AutoLend.Core.Esceptions;
using AutoLend.Data.CoreModels.Customer;
using AutoLend.Data.DataModels.Customer;
using AutoLend.Data.Repositories.Customer;

namespace AutoLend.Core.Services.Customer {
    internal class CustomerService : ICustomerService {

        private readonly ICustomerRepository _customerRepository;
        public CustomerService( ICustomerRepository customerRepository ) {
            _customerRepository = customerRepository;
        }
        public async Task<IEnumerable<Data.DataModels.Customer.Customer?>> GetAllCustomers() {
            return await _customerRepository.GetAllAsync();
        }
        public async Task DeleteCustomer( Guid customerId ) {
            
            if (await _customerRepository.GetByIdAsync(customerId) is null)
                throw new BusinessException("Customer not found or is not active.");


                await _customerRepository.DeleteAsync(customerId);
        }
        public async Task CreateCustomer( CustomerCreateRequest customer ) {

            if (await _customerRepository.IsCustomerFieldUniqueAsync("LicenseNumber",customer.LicenseNumber))
                throw new BusinessException("License number already exists.");


            if (await _customerRepository.IsCustomerFieldUniqueAsync("Email", customer.Email))
                throw new BusinessException("Email already exists.");

            CustomerCreateDTO CustomerDto = new() {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                LicenseNumber = customer.LicenseNumber,
                Phone = customer.Phone,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
            };

            await _customerRepository.CreateAsync(CustomerDto);
        }
        public async Task UpdateCustomer( Guid customerId, CustomerUpdateRequest customer ) {

            if (await _customerRepository.GetByIdAsync(customerId) is null)
                throw new BusinessException("Customer not found.");

            if(!string.IsNullOrEmpty(customer.LicenseNumber))
                if (await _customerRepository.IsCustomerFieldUniqueAsync("LicenseNumber", customer.LicenseNumber, customerId))
                    throw new BusinessException("License number already exists.");

            CustomerUpdateDTO CustomerDto = new() {
                Id = customerId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                LicenseNumber = customer.LicenseNumber,
                Phone = customer.Phone,
                Address = customer.Address,
                DateOfBirth = customer.DateOfBirth,
            };

            await _customerRepository.UpdateAsync(CustomerDto);
        }
        public async Task<Data.DataModels.Customer.Customer?> GetCustomerById( Guid customerId ) {
            return await _customerRepository.GetByIdAsync(customerId) ?? throw new BusinessException("Customer not found.");
        }
    }
}
