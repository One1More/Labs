using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.UserLogin;
using Lab5.Application.Models.Operations;
using Lab5.Application.Models.Users;
using Npgsql;
using Operation = Lab5.Application.Models.Operations.Operation;

namespace Lab5.Infrastracture.DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<UserAccountFindResult> FindUserByAccoutNumber(int number)
    {
        const string sql = @"
            select AccountID
            from Accounts
            where AccountId = @id;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", number);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader.ReadAsync().ConfigureAwait(true) is false)
        {
            return new UserAccountFindResult.NotFound();
        }
        else
        {
            return new UserAccountFindResult.Success();
        }
    }

    public async Task<User?> TryToLogin(int pinCode, int number)
    {
        const string sql = @"
            select AccountID
            from Accounts
            where AccountId = @id and Password = @pinCode;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("id", number)
            .AddParameter("pinCode", pinCode);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader.ReadAsync().ConfigureAwait(true) is false)
            return null;

        return new User(reader.GetInt32(0), UserRole.User);
    }

    public async Task<long> CheckAccountBalance(int number)
    {
        const string sql = @"
            select Money
            from Accounts
            where AccountId = @id;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("id", number);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader.ReadAsync().ConfigureAwait(true) is false)
        {
            return 0;
        }

        return reader.GetInt64(0);
    }

    public async Task MakeDeposit(int number, long money)
    {
        const string sql = @"
            UPDATE Accounts
            SET Money = Money + @money
            WHERE AccountID = @id;";

        await AddOperationToHistory(number, Operation.Deposit, money).ConfigureAwait(true);

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("id", number)
            .AddParameter("money", money);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);
    }

    public async Task<UserBalanceOperationsResult> MakeWithdrawal(int number, long money)
    {
        long moneyAmount = await CheckMoneyAmount(number).ConfigureAwait(true);

        if (moneyAmount - money >= 0)
        {
            const string sql = @"
            UPDATE Accounts
            SET Money = Money - @money
            WHERE AccountID = @id;";

            NpgsqlConnection connection = await _connectionProvider
                .GetConnectionAsync(default)
                .ConfigureAwait(true);

            using var command = new NpgsqlCommand(sql, connection);
            command
                .AddParameter("id", number)
                .AddParameter("money", money);

            await AddOperationToHistory(number, Operation.Withdrawal, money).ConfigureAwait(true);

            using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);

            return new UserBalanceOperationsResult.Success();
        }

        return new UserBalanceOperationsResult.InsufficientFunds();
    }

    public async Task<long> CheckMoneyAmount(int number)
    {
        const string sqlSelect = @"
            select Money
            from Accounts
            where AccountId = @id;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var firstCommand = new NpgsqlCommand(sqlSelect, connection);
        firstCommand.AddParameter("id", number);

        using NpgsqlDataReader reader_ = await firstCommand.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader_.ReadAsync().ConfigureAwait(true) is false)
        {
            return 0;
        }

        return reader_.GetInt64(0);
    }

    public async Task AddOperationToHistory(int number, Operation operation, long moneyAmount)
    {
        const string sql = @"
            INSERT INTO AccountsOperationsHistory
            (AccountId, Operation, MoneyAmount) 
            VALUES (@number, @operation, @money)";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var command = new NpgsqlCommand(sql, connection);
        command
            .AddParameter("number", number)
            .AddParameter("money", moneyAmount)
            .AddParameter("operation", operation);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(true);
    }

    public async Task<IEnumerable<IUserOperation>> CheckHistory(int number)
    {
        const string sqlSelect = @"
            select Operation, MoneyAmount
            from AccountsOperationsHistory
            where AccountId = @id;";

        NpgsqlConnection connection = await _connectionProvider
            .GetConnectionAsync(default)
            .ConfigureAwait(true);

        using var firstCommand = new NpgsqlCommand(sqlSelect, connection);
        firstCommand.AddParameter("id", number);

        using NpgsqlDataReader reader_ = await firstCommand.ExecuteReaderAsync().ConfigureAwait(true);

        if (await reader_.ReadAsync().ConfigureAwait(true) is false)
        {
            return Array.Empty<IUserOperation>();
        }

        var operations = new List<IUserOperation>();

        while (await reader_.ReadAsync().ConfigureAwait(true))
        {
            if (await reader_.GetFieldValueAsync<Operation>(0).ConfigureAwait(true) == Operation.Deposit)
            {
                operations.Add(new DepositOperation(
                    await reader_.GetFieldValueAsync<long>(1).ConfigureAwait(true)));
            }
            else
            {
                operations.Add(new WithdrawalOperation(
                    await reader_.GetFieldValueAsync<long>(1).ConfigureAwait(true)));
            }
        }

        return operations;
    }
}