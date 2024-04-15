using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Npgsql;

namespace Lab5.Infrastracture.DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> TryToLogin(int code)
    {
        const string sql = @"
            select Password
            from SystemPassword
            where Password = @code;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("code", code);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader.ReadAsync().ConfigureAwait(true) is false)
            return null;

        return new User(reader.GetInt32(0), UserRole.Admin);
    }

    public async Task CreateNewAccount(int number, int pinCode)
    {
        const string sql = @"
            INSERT INTO Accounts
            (AccountID, Password, Money)
            values (@number, @pinCode, 0);";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("number", number)
            .AddParameter("pinCode", pinCode);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);
    }

    public async Task ChangeSystemPassword(int pinCode)
    {
        const string sql = @"
            UPDATE SystemPassword
            SET Password = @pinCode;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("pinCode", pinCode);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);
    }
}