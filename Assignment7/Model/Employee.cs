using System.ComponentModel.DataAnnotations;

namespace Assignment7.Model
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        public string Department { get; set; }    
    }
}
