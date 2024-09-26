using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using QuickLink.Infrastructure.Configurations;

namespace QuickLink.Infrastructure.Utils
{
    public class MariaDatabaseManager(IConfiguration configuration)
    {
        private readonly IConfiguration _configuration = configuration;

        public void EnsureDatabase()
        {
            using var connection = new MySqlConnection(_configuration.GetConnectionString(ConnectionStringNames.MariaDb));
            connection.Open();

            var command = new MySqlCommand("CREATE DATABASE IF NOT EXISTS QuickLink;", connection);
            command.ExecuteNonQuery();

            // TODO clean up
            var scalar = new MySqlCommand("SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShortLinks'", connection);
            var tableExists = (long)scalar.ExecuteScalar();

            if (tableExists == 0)
            {
                var createTable = new MySqlCommand(
                "CREATE TABLE ShortLinks (" +
                "Id UNIQUEIDENTIFIER PRIMARY KEY, " +
                "LongURL NVARCHAR(MAX) NOT NULL, " +
                "ShortURL NVARCHAR(MAX) NOT NULL, " +
                "CreatedAt DATETIME NOT NULL)"
                , connection);
                createTable.ExecuteNonQuery();
            }
        }
    }
}
