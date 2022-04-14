using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class PacientsAnalysis
    {
        public int ID { get; set; }
        public string AnalysisDate { get; set; }
        public bool Result { get; set; }
        public string ResultInfo { get; set; }
        public int RecordModelID { get; set; }
        public RecordModel RecordModel { get; set; }
        public int AnalysisModelId { get; set; }
        public AnalysisModel AnalysisModel { get; set; }
        
    }
}
