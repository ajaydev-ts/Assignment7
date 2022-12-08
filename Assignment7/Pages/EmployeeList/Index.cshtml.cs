using Assignment7.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Assignment7.Pages.EmployeeList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IEnumerable<Employee> Employees { get; set; }
        public async Task OnGet()
        {
            Employees = await _db.Employees.ToListAsync();
        }
        public async Task<IActionResult> OnPostDelete(int id)
        {
            var employee = await _db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            _db.Employees.Remove(employee);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
            
        }
    }
}
