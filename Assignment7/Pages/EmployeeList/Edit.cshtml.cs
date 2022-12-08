using Assignment7.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment7.Pages.EmployeeList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Employee Employee { get; set; }

        public async Task OnGet(int id)
        {
            Employee = await _db.Employees.FindAsync(id);
        }

        public async Task <IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                var EmployeeFromDb =await _db.Employees.FindAsync(Employee.Id);
                EmployeeFromDb.EmployeeName=Employee.EmployeeName;
                EmployeeFromDb.Department = Employee.Department;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");


            }
            return RedirectToPage();
        }
    }
}
