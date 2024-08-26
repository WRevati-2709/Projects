using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advisor.Domain
{
    public class Advisor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^(\d{3}-\d{3}-\d{3})|(\d{9})$")]
        [MinLength(9)]
        public string SIN { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        [Phone]
        [MinLength(8)]
        public string Phone { get; set; }
        [RegularExpression("Red|Green|Blue", ErrorMessage = "Invalid Health Status")]
        public string HealthStatus { get; set; }
    }
}
