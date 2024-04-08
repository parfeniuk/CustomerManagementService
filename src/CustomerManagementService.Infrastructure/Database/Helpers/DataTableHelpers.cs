using CustomerManagementService.Domain.Entities;
using CustomerManagementService.Infrastructure.Database.Metadata;
using System.Data;

namespace CustomerManagementService.Infrastructure.Database.Helpers
{
    public static class DataTableHelpers
    {
        public static DataTable ToCustomersDataTable(this IEnumerable<CustomerEntity> customers)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Age", typeof(int));
            dataTable.Columns.Add("FirstName", typeof(string));
            dataTable.Columns.Add("LastName", typeof(string));

            foreach (var customer in customers)
            {
                var row = dataTable.NewRow();
                row["Id"] = customer.Id;
                row["Age"] = customer.Age;
                row["FirstName"] = customer.FirstName;
                row["LastName"] = customer.LastName;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
