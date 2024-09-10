using Employee_Api.Models;
namespace Employee_Api.Repository
{
    public interface IEmployeeRepository
    {
        public Task<IEnumerable<Employee>> GetAllEmployee();

        public Employee? GetEmployeeById(int id);
        public bool Authenticate(AuthenticationDetails auth);
        public Employee AddEmpTodb(Employee employee);

        public bool DeleteEmployeeById(int id);
        public bool UpdateEmployee(Employee employee);
    }
}
