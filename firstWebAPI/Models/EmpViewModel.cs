
namespace FirstWebAPI.Models
{
    public class EmpViewModel
    {
        public int EmpId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Title { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? City { get; set; }
        public int? ReportsTo { get; set; }
    }
}