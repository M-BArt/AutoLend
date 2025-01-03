using AutoLend.Domain.DataModels.Client;

namespace AutoLend.Application.Services.Interfaces {
    public interface ICustomerService {
        Task Create( Customer customer );
        Task Delete( Guid customerId );
        Task Update( Customer customer );
        Task<IEnumerable<Customer?>> GetAll();
        Task<Customer?> GetById( Guid id );
    }
}
