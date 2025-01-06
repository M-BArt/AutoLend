using AutoLend.Data.Resources.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AutoLend.Data.Repositories.Model {
    internal class ModelRepository : IModelRepository {

        private readonly string _connectionString;
        public ModelRepository( IConfiguration configuration ) {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Connection string not provided");
        }
        public async Task<DataModels.Model.Model?> GetByModelNameAsync( string modelName ) {
            using (SqlConnection connection = new(_connectionString)) {
                await connection.OpenAsync();
                return await connection.QueryFirstOrDefaultAsync<DataModels.Model.Model?>(Sql.Model_GetByModelName, new { modelName });
            }
        }
    }
}
