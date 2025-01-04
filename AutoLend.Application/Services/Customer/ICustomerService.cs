using AutoLend.Core.ApiModels.Customer;

namespace AutoLend.Core.Services.Customer
{
    public interface ICustomerService
    {
        Task CreateCustomer(CustomerCreateRequest customer);
        Task DeleteCustomer(Guid customerId);
        Task UpdateCustomer(Guid customerId, CustomerUpdateRequest customer );
        Task<IEnumerable<Data.DataModels.Customer.Customer?>> GetAllCustomers();
        Task<Data.DataModels.Customer.Customer?> GetCustomerById(Guid customerId);
    }
}
