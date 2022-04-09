using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class DoctorFullInfo
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public DoctorUser doctorUser { get; set; }
        public int? DoctorUserId { get; set; }
    }
}
