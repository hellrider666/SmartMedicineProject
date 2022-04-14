using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class RecordModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string RecordDate { get; set; } = DateTime.Now.ToShortDateString();
        public int? DoctorUserId { get; set; }
        public DoctorUser DoctorUser { get; set; }
        public IEnumerable<PacientMedCart> pacientMedCarts { get; set; }
        public IEnumerable <PacientsAnalysis> pacientsAnalyses { get; set; }
    }
}
