using CustomerManagementService.Infrastructure.DbMigration.Helpers;
using Microsoft.Extensions.Configuration;

namespace CustomerManagementService.Infrastructure.DbMigration
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var result = DbUpgrader.PerformUpgrade(configuration.GetConnectionString("CustomerManagementService"));

            if (!result.Successful)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(result.Error);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Success!");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}
