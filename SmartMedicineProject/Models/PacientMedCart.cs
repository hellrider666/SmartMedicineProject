using System;

namespace SmartMedicineProject.Models
{
    public class PacientMedCart
    {
        public int ID { get; set; }
        public int Age { get; set; }
        public DateTime DateBorn { get; set; }
        public string Status { get; set; }
        public string Info { get; set; }
        public int RecordModelId { get; set; }
        public RecordModel RecordModel { get; set; }
    }
}
