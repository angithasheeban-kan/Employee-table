using System.ComponentModel.DataAnnotations;

namespace Employee_Table.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; }
        public string? Status { get; set; }
    }
}


// namespace Employee_Table.Models
// {
//     public class Employee
//     {
//         [Key]
//         public int EmployeeID { get; set; }

//         [Required, StringLength(100)]
//         public string Name { get; set; }

//         [Required, StringLength(100)]
//         public string Position { get; set; }

//         [Required, StringLength(30)]
//         public string Status { get; set; }
//     }
// }














































// using System.ComponentModel.DataAnnotations;
// using System.ComponentModel.DataAnnotations.Schema;

// namespace Employee_Table.Models.DBEntities
// {
//     public class Employee
//     {
//         [Key]
//         [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
//         public int EmployeeId { get; set; }

//         [Column("Name")]
//         public string? Name { get; set; }

//         [Column("Position")]
//         public string? Position { get; set; }

//         [Required]
//         public string? Status { get; set; }
//     }
// }
