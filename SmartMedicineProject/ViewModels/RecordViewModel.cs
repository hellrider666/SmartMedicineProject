using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.ViewModels
{
    public class RecordViewModel
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
