using AutoLend.Data.CoreModels.Customer;
using AutoLend.Data.DataModels.Customer;

namespace AutoLend.Data.Repositories.Customer {
    public interface ICustomerRepository {
        Task CreateAsync( CustomerCreateDTO customer );
        Task<IEnumerable<DataModels.Customer.Customer?>> GetAllAsync();
        Task<DataModels.Customer.Customer?> GetByIdAsync( Guid customerId );
        Task UpdateAsync( CustomerUpdateDTO customer );
        Task DeleteAsync( Guid customerId );
        Task<bool> IsCustomerFieldUniqueAsync( string value, string field, Guid? excludeCustomerId = null );
        Task<CustomerGetByLicenseNumber?> GetByLicenseNumber( string LicenseNumber );
        Task ChangeActiveRental( Guid customerId );

    }
}
