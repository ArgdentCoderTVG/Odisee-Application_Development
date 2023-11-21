using System.ComponentModel.DataAnnotations;

namespace Demo_EF.Models
{
    public class DepartmentModel
    {
        [Required]
        public string Name { get; set; }
    }
}
