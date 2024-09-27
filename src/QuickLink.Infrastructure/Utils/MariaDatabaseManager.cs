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

            var command = new MySqlCommand(
                "CREATE DATABASE IF NOT EXISTS QuickLink;",
                connection);
            command.ExecuteNonQuery();

            var isTableExistsCommand = new MySqlCommand(
                "SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'ShortLinks'",
                connection);
            var isTableExists = (long)isTableExistsCommand.ExecuteScalar();

            if (isTableExists == 0)
            {
                var useDbCommand = new MySqlCommand(
                    "USE QuickLink;",
                    connection);
                useDbCommand.ExecuteNonQuery();

                var createTableCommand = new MySqlCommand("" +
                    "CREATE TABLE ShortLinks (" +
                        "Id INT AUTO_INCREMENT PRIMARY KEY," +
                        "LongUrl VARCHAR(2048) NOT NULL," +
                        "ShortUrl VARCHAR(256) NOT NULL," +
                        "CreatedAt DATETIME NOT NULL," +
                        "ClickCount INT NOT NULL DEFAULT 0 " +
                    ");",
                    connection);
                createTableCommand.ExecuteNonQuery();
            }
        }
    }
}
