using Employee_Api.Models;
using Microsoft.AspNetCore.Mvc;
using Employee_Api.Services;
using Employee_Api.RSA;

namespace Employee_Api.Controllers
{
    [ApiController]
    [Route("api/emp")]
    public class EmployeeController : Controller
    {
        
        private readonly IEmployeeService employeeService;
        private readonly IRSAHelper RSAHelper;
        //EmployeeService employeeService1;


        
        public EmployeeController(IEmployeeService employeeService,IRSAHelper rsaHelper) {
            this.employeeService = employeeService;
            this.RSAHelper= rsaHelper;
        }

           
        
         [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            Console.WriteLine("Hit");
           // return await employeeService1.GetEmployees();
           var a = await this.employeeService.GetEmployees();
            return await this.employeeService.GetEmployees();           
        }

        [HttpGet("{id}")]

        public Employee? GetEmployee(int id)
        {
            return this.employeeService.GetEmployeeById(id);
        }
        [HttpPut]
        [Route("pass")]

        public bool AuthenticateEmployee(AuthenticationDetails auth) {

            var auth1 = new AuthenticationDetails();
            auth1.Email_id=RSAHelper.Decrypt(auth.Email_id); 
            auth1.Password=RSAHelper.Decrypt(auth.Password); ;
           return this.employeeService.Authenticate(auth1);
        }

        [HttpPost]
        public Employee AddEmployee(Employee employee)
        {
            Console.WriteLine(employee);
            return this.employeeService.AddEmployee(employee);
        }

        [HttpDelete("{id}")]
        public bool DeleteEmployee(int id)
        {
            return this.employeeService.DeleteEmployeeById(id);
        }

        [HttpPut]
        public bool PutEmployee(Employee employee)
        {
            return this.employeeService.UpdateEmployee(employee);
        }        
    }
}
