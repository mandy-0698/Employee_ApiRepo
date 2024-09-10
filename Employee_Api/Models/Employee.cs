using System.Transactions;

namespace Employee_Api.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Dept { get; set; }
        public Int64 ? ContactNo { get; set; }
    }
}
