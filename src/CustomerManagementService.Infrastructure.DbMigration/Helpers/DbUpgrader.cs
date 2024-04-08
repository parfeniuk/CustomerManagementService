using DbUp.Engine;
using DbUp;
using System.Reflection;

namespace CustomerManagementService.Infrastructure.DbMigration.Helpers
{
    public static class DbUpgrader
    {
        public static DatabaseUpgradeResult PerformUpgrade(string connectionString)
        {
            EnsureDatabase.For.SqlDatabase(connectionString);

            var upgrader = DeployChanges.To
                .SqlDatabase(connectionString)
                .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                .LogToConsole()
                .Build();

            var result = upgrader.PerformUpgrade();

            return result;
        }
    }
}
