using Dapper;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Prototype6.Models;

public class SpecRepository : ISpecRepository
{
    private readonly DapperContext _context;

    public SpecRepository(DapperContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Spec>> GetAll()
    {
        using var connection = _context.GetConnection();
        const string query = "SELECT * FROM Spec";
        return await connection.QueryAsync<Spec>(query);
    }

    public async Task<Spec> GetById(int id)
    {
        using var connection = _context.GetConnection();
        const string query = "SELECT * FROM Spec WHERE Id = @Id";
        return await connection.QueryFirstOrDefaultAsync<Spec>(query, new { Id = id });
    }

    public async Task<int> Create(Spec spec)
    {
        using var connection = _context.GetConnection();
        const string query = "INSERT INTO Spec (Nama, Spesies, Klasifikasi) VALUES (@Nama, @Spesies, @Klasifikasi)";

        return await connection.ExecuteAsync(query, spec);
    }

    public async Task<int> Update(Spec spec)
    {
        using var connection = _context.GetConnection();
        const string query = "UPDATE Spec SET Nama = @Nama, Spesies = @Spesies, Klasifikasi = @Klasifikasi WHERE Id = @Id";
        return await connection.ExecuteAsync(query, spec);
    }

    public async Task<int> Delete(int id)
    {
        using var connection = _context.GetConnection();
        const string query = "DELETE FROM Spec WHERE Id = @Id";
        return await connection.ExecuteAsync(query, new { Id = id });
    }
}
