using firstWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;



namespace FirstWebAPI.Models
{
    public class RepositoryEmp
    {
        private NorthwindContext _context;
        public RepositoryEmp(NorthwindContext context)
        {
            _context = context;
        }
        public List<Employee> GetAllEmp()
        {



            return _context.Employees.ToList();



        }
        public Employee GetEmployeeId(int id)
        {
            Employee employee = _context.Employees.Find(id);
            return employee;
        }



        public Employee AddEmployee(Employee newemployee)
        {
            Employee? foundemp = _context.Employees.Find(newemployee.EmployeeId);
            if (foundemp != null)
            {
                throw new Exception("Already found");
            }
            EntityState es = _context.Entry(newemployee).State;
            Console.WriteLine($"EntityState B4Add :{es.GetDisplayName()}");
            _context.Employees.Add(newemployee);
            es = _context.Entry(newemployee).State;
            Console.WriteLine($"Entitystate after add:{es.GetDisplayName()}");
            _context.SaveChanges();
            es = _context.Entry(newemployee).State;
            Console.WriteLine($"Entitystate after save change:{es.GetDisplayName()}");
            return newemployee;
        }
        public int UpdateEmployee(Employee updatedEmployeeData)
        {
            EntityState es = _context.Entry(updatedEmployeeData).State;
            Console.WriteLine($"EntityState B4Add :{es.GetDisplayName()}");
            _context.Employees.Update(updatedEmployeeData);
            es = _context.Entry(updatedEmployeeData).State;
            Console.WriteLine($"Entitystate after add:{es.GetDisplayName()}");
            // Save changes to the database
            int result = _context.SaveChanges();
            es = _context.Entry(updatedEmployeeData).State;
            Console.WriteLine($"Entitystate after save change:{es.GetDisplayName()}");
            return result;



        }
        public int DeleteEmployee(int id)
        {
            Employee? empDelete = _context.Employees.Find(id);
            EntityState es = EntityState.Deleted;
            int result = 0;
            if (empDelete != null)
            {
                es = _context.Entry(empDelete).State;
                Console.WriteLine($"EntityState B4Add :{es.GetDisplayName()}");
                _context.Employees.Remove(empDelete);
                es = _context.Entry(empDelete).State;
                Console.WriteLine($"Entitystate after add:{es.GetDisplayName()}");
                _context.SaveChanges();
                es = _context.Entry(empDelete).State;
                Console.WriteLine($"Entitystate after save change:{es.GetDisplayName()}");
            }
            return result;






        }
    }
}