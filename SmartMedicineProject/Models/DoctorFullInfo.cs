using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class DoctorFullInfo
    {
        public int ID { get; set; }
        public int? Age { get; set; }
        public DateTime? DateBorn { get; set; }
        public string Position { get; set; }
        public string Education { get; set; }
        public int? Exp { get; set; }
        public string Adress { get; set; }
        public string PassportSerialNumber { get; set; }
        public string TIN_passport { get; set; }
        public DoctorUser doctorUser { get; set; }
        public int? DoctorUserId { get; set; }
    }
}
