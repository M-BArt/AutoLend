using AutoLend.Data.CoreModels.Customer;
using AutoLend.Data.DataModels.Customer;
using AutoLend.Data.Resources.Customer;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Transactions;

namespace AutoLend.Data.Repositories.Customer {
    internal class CustomerRepository : ICustomerRepository {

        private readonly string _connectionString;
        public CustomerRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }
        public async Task CreateAsync( CustomerCreateDTO customer ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    customer.FirstName,
                    customer.LastName,
                    customer.Email,
                    customer.Phone,
                    customer.Address,
                    customer.LicenseNumber,
                    customer.DateOfBirth,
                };

                await connection.ExecuteAsync(Sql.Customer_Create, parameters);
            }
        }
        public async Task<IEnumerable<DataModels.Customer.Customer?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryAsync<DataModels.Customer.Customer>(Sql.Customer_GetAll);
            }
        }
        public async Task<DataModels.Customer.Customer?> GetByIdAsync( Guid customerId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<DataModels.Customer.Customer>(Sql.Customer_GetById, new { customerId });
            }
        }
        public async Task UpdateAsync( CustomerUpdateDTO customer ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                var parameters = new {
                    customer.Id,
                    customer.FirstName,
                    customer.LastName,
                    customer.Phone,
                    customer.Address,
                    customer.LicenseNumber,
                    customer.DateOfBirth,
                };

                await connection.ExecuteAsync(Sql.Customer_Update, parameters);
            }
        }
        public async Task DeleteAsync( Guid customerId ) {

            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();

                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) {
                    await connection.ExecuteAsync(Sql.Customer_Delete, new { customerId });
                    transaction.Complete();
                }
            }
        }
        public async Task<bool> IsCustomerFieldUniqueAsync( string field, string value, Guid? excludeCustomerId = null ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<bool>(Sql.Customer_IsCustomerFieldUnique, new { field, value, excludeCustomerId });
            }
        }
        public async Task<CustomerGetByLicenseNumber?> GetByLicenseNumber( string licenseNumber ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<CustomerGetByLicenseNumber>(Sql.Customer_GetByLicenseNumber, new { licenseNumber });
            }
        }

        public async Task ChangeActiveRental( Guid customerId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                await connection.ExecuteAsync(Sql.Customer_ChangeActiveRental, new { customerId });
            }
        }


    }   
}
