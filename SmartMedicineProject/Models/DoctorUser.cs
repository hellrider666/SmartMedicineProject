using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class DoctorUser
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public string PersonalCode { get; set; }
        public int? RoleModelId { get; set; }
        public RoleModel RoleModel { get; set; }     
        public IEnumerable<DoctorFullInfo> doctorFullInfos { get; set; }
        public IEnumerable<RecordModel> recordModels { get; set; }
        
    }
}
