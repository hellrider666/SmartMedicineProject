using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMedicineProject.Models
{
    public class SMAppContext : DbContext
    {
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
            string userRoleName = "User";

            RoleModel AdminRole = new RoleModel { Id = 1, Name = adminRoleName };
            RoleModel UserRole = new RoleModel { Id = 2, Name = userRoleName };

            modelBuilder.Entity<RoleModel>().HasData(new RoleModel[] { AdminRole, UserRole });
            base.OnModelCreating(modelBuilder);
        }
    }
}
