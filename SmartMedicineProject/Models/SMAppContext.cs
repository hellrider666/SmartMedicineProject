using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class SMAppContext : DbContext
    {
        public DbSet<AnalysisModel> analysisModels { get; set; }
        public DbSet<PacientMedCart> pacientMedCarts { get; set; }
        public DbSet<RecordModel> recordModels { get; set; }
        public DbSet<DoctorFullInfo> doctorFullInfos { get; set; }
        public DbSet<DoctorUser> doctorUsers { get; set; }
        public DbSet<RoleModel> roleModels { get; set; }
        public SMAppContext(DbContextOptions<SMAppContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "Admin";
            string undefinedRoleName = "Undefined";
            string doctorRoleName = "Doctor";


            RoleModel AdminRole = new RoleModel { Id = 1, Name = adminRoleName };
            RoleModel UserRole = new RoleModel { Id = 2, Name = doctorRoleName };
            RoleModel UndefinedRole = new RoleModel { Id = 3, Name = undefinedRoleName };

            modelBuilder.Entity<RoleModel>().HasData(new RoleModel[] { AdminRole, UserRole });
            base.OnModelCreating(modelBuilder);
        }
    }
}
