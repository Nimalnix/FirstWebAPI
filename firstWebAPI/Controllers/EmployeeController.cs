using firstWebAPI.Models;


using Microsoft.AspNetCore.Mvc;



namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private EmployeeRepository _repositoryEmployee;
        public EmpController(EmployeeRepository repository)
        {
            _repositoryEmployee = repository;
        }
        [HttpGet("/GetAllEmployees")]
        public IEnumerable<EmployeeViewModel> GetAllEmp()
        {
            List<Employee> employees = _repositoryEmployee.GetAllEmp();
            var emplist = (
                from emp in employees
                select new EmployeeViewModel()
                {
                    EmpId = emp.EmployeeId,
                    FirstName = emp.FirstName,
                    LastName = emp.LastName,
                    BirthDate =emp.BirthDate,
                    HireDate = emp.HireDate,
                    Title = emp.Title,
                    City = emp.City,
                    ReportTo = emp.ReportsTo
                }
       ).ToList();
            return emplist;
        }
        [HttpPost]
        public Employee EmployeeDetails(int id)
        {
            Employee employees = _repositoryEmployee.GetEmployeeId(id);
            return employees;
        }
       

        [HttpPut]
        public void Update(int id, Employee updatedEmployeeData)
        {
            Employee employee = _repositoryEmployee.UpdateCustomer(id, updatedEmployeeData);



        }
    }
}
