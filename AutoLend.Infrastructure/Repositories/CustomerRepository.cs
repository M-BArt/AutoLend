using AutoLend.Domain.DataModels.Customer;
using AutoLend.Domain.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Infrastructure.Repositories {
    internal class CustomerRepository : ICustomerRepository {

        private readonly string _connectionString;

        public CustomerRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }

        public async Task CreateAsync( Customer customer ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Customer\\Customer_Create.sql"));
                await connection.ExecuteAsync(query, customer);
            }
        }
        public async Task<IEnumerable<Customer?>> GetAllAsync() {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Customer\\Customer_GetAll.sql"));
                return await connection.QueryAsync<Customer>(query);
            }
        }
        public async Task<Customer?> GetByIdAsync( Guid customerId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Customer\\Customer_GetById.sql"));
                return await connection.QueryFirstOrDefaultAsync<Customer>(query, new { customerId });
            }
        }
        public async Task UpdateAsync( Customer customer ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Customer\\Customer_Update.sql"));
                await connection.ExecuteAsync(query, new { customer });
            }
        }
        public async Task DeleteAsync( Guid customerId ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                var query = File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\AutoLend\\AutoLend.Infrastructure\\Resources\\Customer\\Customer_Delete.sql"));
                await connection.ExecuteAsync(query, new { customerId });
            }
        }
    }
}
