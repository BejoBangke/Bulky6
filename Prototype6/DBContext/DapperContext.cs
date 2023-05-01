using System;

using Microsoft.Extensions.Configuration;
using MySqlConnector;

public class DapperContext
{
    private readonly string _connectionString;

    public DapperContext(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection")!;
        if (string.IsNullOrEmpty(_connectionString))
        {
            throw new Exception("Database connection string not found or empty.");
        }
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}
