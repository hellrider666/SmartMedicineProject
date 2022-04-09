using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<DoctorUser> doctorUsers { get; set; }        
    }
}
