using System;


namespace SmartMedicineProject.Models
{
    public class AnalysisModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime AnalysisDate { get; set; }
        public bool Result { get; set; }
        public string ResultInfo { get; set; }
        public int RecordModelID { get; set; }
        public RecordModel RecordModel { get; set; }
    }
}
