using Dapper;
using System.Data;
using System.Data.SqlClient;
using TestingWebApi.Models;

namespace TestingWebApi.Repository
{
    public class Testing : ITesting
    {
        public async Task<IEnumerable<Message>> SaveMessages(Dictionary<string, string> sqlParameterArray, string procName)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            using (var _sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=RevisionMVC;Integrated Security=True"))
            {

                await _sqlConnection.OpenAsync();
                DynamicParameters dynamic = new DynamicParameters();
                foreach (var sqlParameter in sqlParameterArray) dynamic.Add("@" + sqlParameter.Key, sqlParameter.Value);
                return await _sqlConnection.QueryAsync<Message>( procName, dynamic, commandType:CommandType.StoredProcedure);
            }
            return null;
        }

        public async Task<IEnumerable<Message>> FetchData(string procName)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            using (var _sqlConnection = new SqlConnection("Data Source=localhost;Initial Catalog=RevisionMVC;Integrated Security=True"))
            {

                await _sqlConnection.OpenAsync();
                DynamicParameters dynamic = new DynamicParameters();
                return await _sqlConnection.QueryAsync<Message>(procName, dynamic, commandType: CommandType.StoredProcedure);
            }
            return null;
        }
    }
}
