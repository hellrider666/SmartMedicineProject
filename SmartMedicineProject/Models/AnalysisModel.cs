using System;
using System.Collections;
using System.Collections.Generic;

namespace SmartMedicineProject.Models
{
    public class AnalysisModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable <PacientsAnalysis> pacientsAnalyses { get; set; }
        
    }
}
