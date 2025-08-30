using Employee_Table.DAL;
using Employee_Table.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Employee_Table.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDBContext _context;

        public EmployeeController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: Employee
        [HttpGet]
        public IActionResult Index()
        {
            var employeelist = _context.Employees
                .Select(employee => new EmployeeViewModel
                {
                    EmployeeId = employee.EmployeeId,
                    Name = employee.Name,
                    Position = employee.Position,
                    Status = employee.Status
                }).ToList();

            return View(employeelist); // View is strongly typed to List<EmployeeViewModel>
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var emp = _context.Employees.FirstOrDefault(e => e.EmployeeId == id);
            if (emp == null) return NotFound();

            // Map to your ViewModel (since your Index uses EmployeeViewModel)
            var vm = new Employee_Table.Models.EmployeeViewModel
            {
                EmployeeId = emp.EmployeeId,
                Name       = emp.Name,
                Position   = emp.Position,
                Status     = emp.Status
            };

            return View(vm); // this will look for Views/Employee/details.cshtml
        }

        // GET: Employee/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View(new EmployeeViewModel()); // View expects EmployeeViewModel
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = new Employee
                {
                    Name = model.Name,
                    Position = model.Position,
                    Status = model.Status
                };

                _context.Employees.Add(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employee/Edit/5
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            var vm = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Position = employee.Position,
                Status = employee.Status
            };

            return View(vm); // View expects EmployeeViewModel
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var employee = _context.Employees.Find(model.EmployeeId);
                if (employee == null) return NotFound();

                employee.Name = model.Name;
                employee.Position = model.Position;
                employee.Status = model.Status;

                _context.Employees.Update(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Employee/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee == null) return NotFound();

            var vm = new EmployeeViewModel
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                Position = employee.Position,
                Status = employee.Status
            };

            return View(vm); // View expects EmployeeViewModel
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var employee = _context.Employees.Find(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
