using SmartMedicineProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.ViewModels
{
    public class PacientsInfoViewModel
    {
        public IEnumerable<RecordModel> recordModels { get; set; }
        public string PhoneNumber { get; set; }
        public string RecordDate { get; set; }
    }
}

