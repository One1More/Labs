using Itmo.Dev.Platform.Postgres.Plugins;
using Lab5.Application.Models.Operations;
using Npgsql;

namespace Lab5.Infrastracture.DataAccess.Plugins;

public class MuppingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<Operation>();
    }
}