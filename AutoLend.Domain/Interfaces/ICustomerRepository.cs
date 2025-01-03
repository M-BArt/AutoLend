using AutoLend.Domain.DataModels.Client;

namespace AutoLend.Domain.Interfaces {
    public interface ICustomerRepository {
        Task CreateAsync(Customer customer);
        Task<IEnumerable<Customer?>> GetAllAsync();
        Task<Customer?> GetByIdAsync(Guid customerId);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
    }
}
