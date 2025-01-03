using AutoLend.Domain.DataModels.Customer;

namespace AutoLend.Application.Services.Interfaces {
    public interface ICustomerService {
        Task CreateCustomer( Customer customer );
        Task DeleteCustomer( Guid customerId );
        Task UpdateCustomer( Customer customer );
        Task<IEnumerable<Customer?>> GetAllCustomers();
        Task<Customer?> GetCustomerById( Guid customerId );
    }
}
