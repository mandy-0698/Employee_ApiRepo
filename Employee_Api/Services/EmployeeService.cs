using Employee_Api.Models;
using Employee_Api.Repository;
using System.Runtime.CompilerServices;

namespace Employee_Api.Services
{
    public class EmployeeService: IEmployeeService
    {

        private readonly IEmployeeRepository repository;
        public EmployeeService(IEmployeeRepository repository)
        {
            //Console.WriteLine("instance created for repository");
            Console.WriteLine(this);
            this.repository = repository;
        }
        /// <summary>
        /// Get list of employees
        /// </summary>
        /// <returns></returns>
        public  async Task<IEnumerable<Employee>> GetEmployees()
        {
            //Console.WriteLine((Employee)this.repository.GetAllEmployee());
            return await this.repository.GetAllEmployee();
        }

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Employee GetEmployeeById(int id)
        {

#pragma warning disable CS8603 // Possible null reference return.
             return this.repository.GetEmployeeById(id);
#pragma warning restore CS8603 // Possible null reference return.
        }


        /// <summary>
        /// To enter a new employee data in the existing employee list
        /// </summary>
        /// <param name="data"></param>
        /// 

        public bool Authenticate(AuthenticationDetails auth)
        {
            return this.repository.Authenticate(auth);
        }
        public Employee AddEmployee(Employee employee)
        {
            return this.repository.AddEmpTodb(employee);
        }
       
        /// <summary>
        /// Deleting a particular employee by Id if the id exists
        /// </summary>
        /// <param name="id"></param>
        public bool DeleteEmployeeById(int id)
        {
            return this.repository.DeleteEmployeeById(id);
        }

        /// <summary>
        /// Updating a paticular employee by Id along with other information which need to be updated
        /// </summary>
        /// <param name="e"></param>
        public bool UpdateEmployee(Employee employee)
        {

            return this.repository.UpdateEmployee(employee);
        }
    }
}
