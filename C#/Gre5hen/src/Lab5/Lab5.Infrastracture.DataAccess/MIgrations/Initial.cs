using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastracture.DataAccess.MIgrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        CREATE TYPE Operation as enum (
            'deposit',
            'withdrawal'
        );
        
        CREATE TABLE Accounts (
            AccountID INT PRIMARY KEY,
            Password INT,
            Money BIGINT
        );

        CREATE TABLE AccountsOperationsHistory (
            AccountID INT REFERENCES Accounts(AccountID),
            Operation Operation,
            MoneyAmount BIGINT
        );

        CREATE TABLE SystemPassword (
            Password INT
        );

        INSERT INTO SystemPassword (Password) VALUES (123);
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table Accounts;
        drop table AccountsOperationsHistory;
        drop table SystemPassword;

        drop type Operation;
        """;
}