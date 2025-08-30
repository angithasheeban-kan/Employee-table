using System.ComponentModel.DataAnnotations;

namespace Employee_Table.Models  // <-- MUST match the view's namespace
{
    public class EmployeeViewModel
    {
        [Display(Name = "Employee ID")]
        public int EmployeeId { get; set; }

        [Display(Name = "Employee Name")]
        public string? Name { get; set; }

        [Display(Name = "Position")]
        public string? Position { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; }
    }
}
