using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNet.Testcontainers.Builders;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testcontainers.PostgreSql;
using Npgsql;

namespace DemoProject.MSTest;

[TestClass]
public class PostgresTestcontainer
{
    private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder().Build();

    [TestInitialize]
    public Task InitializeAsync()
    {
        return _postgreSqlContainer.StartAsync();
    }

    [TestCleanup]
    public Task DisposeAsync()
    {
        return _postgreSqlContainer.DisposeAsync().AsTask();
    }

    [TestMethod]
    public void ConnectionStateReturnsOpen()
    {
        // Given
        using DbConnection connection = new NpgsqlConnection(_postgreSqlContainer.GetConnectionString());

        // When
        connection.Open();

        // Then
        Assert.AreEqual(ConnectionState.Open, connection.State);
    }

    [TestMethod]
    public async Task ExecScriptReturnsSuccessful()
    {
        // Given
        const string scriptContent = "SELECT 412;";

        // When
        var execResult = await _postgreSqlContainer.ExecScriptAsync(scriptContent);

        // Then
        //Assert.True(0L.Equals(execResult.ExitCode), execResult.Stderr);
        Assert.AreEqual(0, execResult.ExitCode);
    }
}
