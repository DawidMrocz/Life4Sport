using System.Data;
using System.Transactions;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace Framework.Shared.Databases.Dapper.DapperConfiguration
{
    public interface IDapperConfiguration
    {
        string ConnectionString { get; }
        TimeSpan DefaultTimeout { get; }
        IsolationLevel DefaultIsolationLevel { get; }
        TransactionScopeOption DefaultScopeOption { get; }
        CommandType DefaultCommandType { get; }
    }
}
