using Employee_Api.Models;
using Npgsql;
using Dapper;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Employee_Api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository() { }


        public async Task<IEnumerable<Employee>> GetAllEmployee()
        {
            IEnumerable<Employee> data;
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            try
            {
                using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=nimki;Database=postgres"))
                {
                    data = await connection.QueryAsync<Employee>("Select * from \"Employee\" order by \"Id\";");


                }
                return data;

            }
            catch (Exception ex)
            {

                throw;
            }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used

        }
        public Employee? GetEmployeeById(int id)
        {
            Employee data = new Employee();
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            try
            {
                string sqlEmpDetail = "SELECT * FROM public.\"Employee\" WHERE \"Id\" = @empId;";
                using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=nimki;Database=postgres"))
                    return connection.QueryFirstOrDefault<Employee>(sqlEmpDetail, new { empId = id });

            }
            catch (Exception ex)
            {

                throw;
            }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
        }

        public bool Authenticate(AuthenticationDetails auth)
        {
            //string password = "";
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            try
            {
                string sqlPassDetail = "SELECT \"Password\" FROM public.\"Authentication\" WHERE \"Email_id\" = @email;";
                using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=nimki;Database=postgres"))
                    return connection.QueryFirstOrDefault<string>(sqlPassDetail, new { email = auth.Email_id }) == auth.Password;

            }
            catch (Exception ex)
            {

                throw;
            }
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
#pragma warning disable CS0162 // Unreachable code detected
            return false;
#pragma warning restore CS0162 // Unreachable code detected
        }
        public Employee AddEmpTodb(Employee employee)
        {
           
                string query = "INSERT INTO public.\"Employee\" VALUES (@emp_id,@name,@dept,@contact) ";
                using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=nimki;Database=postgres"))
                {
                    connection.Open();
                    connection.Query<Employee>(query, new { emp_id = employee.Id, name = employee.Name, dept = employee.Dept, contact = employee.ContactNo });
                }

                //employees.Add(employee);
                return employee;
           
           
        }

        public bool DeleteEmployeeById(int id)
        {

            if (GetEmployeeById(id) != null)
            {
                string query = "DELETE FROM public.\"Employee\" WHERE \"Id\"=@empId";
                using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=nimki;Database=postgres"))
                {
                    connection.Open();
                    connection.Query<Employee>(query, new { empId = id });
                }
                return true;
            }
            return false;
        }
        public bool UpdateEmployee(Employee employee)
        {

            if (GetEmployeeById(employee.Id) != null)
            {
                string query = "UPDATE public.\"Employee\" SET \"Name\"=@name,\"Dept\"=@dept,\"ContactNo\"=@contact WHERE \"Id\"=@empId";
                using (var connection = new NpgsqlConnection("Host=localhost;Username=postgres;Password=nimki;Database=postgres"))
                {
                    connection.Open();
                    connection.Query(query, new { name = employee.Name, dept = employee.Dept, contact = employee.ContactNo, empId = employee.Id });
                }
                return true;
            }

            return false;

        }
    }
}
