using firstWebAPI.Models;
using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private RepositoryEmp _repositoryEmployee;
        public EmployeeController(RepositoryEmp repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmpViewModel> GetAllEmp()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            var emplist = (
                from emp in employees
                select new EmpViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate = emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportsTo = emp.ReportsTo
                }
        ).ToList();
            return emplist;
        }

        [HttpGet]
        // GET: EmployeeController
        public List<Employee> GetEmployees()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            return employees;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
        [HttpPost("/addEmp")]
        public IActionResult AddEmployee([FromBody] EmpViewModel employeeRequest)
        {
            if (employeeRequest == null)
            {
                return BadRequest("Employee data is missing in the request.");
            }
            Employee newEmployee = new Employee
            {
                FirstName = employeeRequest.FirstName,
                LastName = employeeRequest.LastName,
                BirthDate = employeeRequest.BirthDate,
                HireDate = employeeRequest.HireDate,
                Title = employeeRequest.Title,
                City = employeeRequest.City,
                ReportsTo = employeeRequest.ReportsTo > 0 ? employeeRequest.ReportsTo : null
            };





            Employee addedEmployee = _repositoryEmployee.AddEmployee(newEmployee);





            // Return a Created response with the newly created employee
            return CreatedAtAction(nameof(EmployeeDetails), new { id = addedEmployee.EmployeeId }, addedEmployee);



        }
        [HttpPut]
        public int Put(int id, [FromBody] Employee updatedEmployeeData)
        {
            updatedEmployeeData.EmployeeId = id;
            int savedEmployee = _repositoryEmployee.UpdateEmployee(updatedEmployeeData);
            return savedEmployee;



        }
        [HttpDelete]
        public int DeleteEmployee(int id)
        {




            _repositoryEmployee.DeleteEmployee(id);
            return 1;
        }

    }
}


