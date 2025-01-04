using AutoLend.Data.CoreModels.Customer;

namespace AutoLend.Data.Repositories.Customer
{
    public interface ICustomerRepository
    {
        Task CreateAsync(CustomerCreateDTO customer );
        Task<IEnumerable<DataModels.Customer.Customer?>> GetAllAsync();
        Task<DataModels.Customer.Customer?> GetByIdAsync(Guid customerId);
        Task UpdateAsync(CustomerUpdateDTO customer);
        Task DeleteAsync(Guid customerId);
    }
}
