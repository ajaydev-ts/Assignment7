using Assignment7.Model;
using Microsoft.AspNetCore.Mvc;

namespace Assignment7.Controllers
{
    [Route("api/Employee")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db= db;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _db.Employees.ToList()});
        }
    }
}
