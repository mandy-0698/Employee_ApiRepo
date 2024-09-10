using Employee_Api.Models;

namespace Employee_Api.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        public Employee? GetEmployeeById(int id);

        public bool Authenticate(AuthenticationDetails auth);

        public Employee AddEmployee(Employee e1);

        public bool DeleteEmployeeById(int id);

        public bool UpdateEmployee(Employee e);

    }
}
